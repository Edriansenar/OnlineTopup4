using OnlineTopupDataService;
using OnlineTopupCommon;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OnlineTopupDataService
{
    public class JsonFileDataService : ITopupDataService
    {
        static List<UserAccount> userAccounts = new List<UserAccount>();
        static Dictionary<int, List<(string GameName, string Amount)>> cartStorage = new();
        private List<CartItem> _cartItems = new List<CartItem>();

        static string userFilePath = "useraccounts.json";
        static string cartFilePath = "cartitems.json";

        private int nextUserId = 1;

        public JsonFileDataService()
        {
            ReadJsonUserData();
            ReadJsonCartData();
            if (userAccounts.Any())
                nextUserId = userAccounts.Max(u => u.Id) + 1;
        }

        private void ReadJsonUserData()
        {
            if (!File.Exists(userFilePath)) File.WriteAllText(userFilePath, "[]");

            string jsonText = File.ReadAllText(userFilePath);
            userAccounts = JsonSerializer.Deserialize<List<UserAccount>>(jsonText,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new();
        }

        private void ReadJsonCartData()
        {
            if (!File.Exists(cartFilePath)) File.WriteAllText(cartFilePath, "{}");

            string jsonText = File.ReadAllText(cartFilePath);
            cartStorage = JsonSerializer.Deserialize<Dictionary<int, List<(string, string)>>>(jsonText,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new();
        }

        private void WriteJsonUserData()
        {
            string json = JsonSerializer.Serialize(userAccounts, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(userFilePath, json);
        }

        private void WriteJsonCartData()
        {
            string json = JsonSerializer.Serialize(cartStorage, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(cartFilePath, json);
        }

        public void CreateAccount(UserAccount userAccount)
        {
            userAccount.Id = nextUserId++;
            userAccounts.Add(userAccount);
            WriteJsonUserData();
        }

        public List<UserAccount> GetAccounts() => userAccounts;

        public void RemoveAccount(UserAccount userAccount)
        {
            userAccounts.RemoveAll(acc => acc.User == userAccount.User);
            WriteJsonUserData();
        }

        public void UpdateAccount(UserAccount userAccount)
        {
            var index = userAccounts.FindIndex(u => u.Id == userAccount.Id);
            if (index >= 0)
            {
                userAccounts[index] = userAccount;
                WriteJsonUserData();
            }
        }

        public bool ValidateAccount(string username, string password)
        {
            return userAccounts.Any(u => u.User == username && u.Pass == password);
        }

        public UserAccount GetAccountByUsername(string username)
        {
            return userAccounts.FirstOrDefault(u => u.User == username);
        }

        public void AddCartItem(int userId, string gameName, string amount)
        {
            if (!cartStorage.ContainsKey(userId))
            {
                cartStorage[userId] = new List<(string, string)>();
            }
            cartStorage[userId].Add((gameName, amount));
            WriteJsonCartData();
        }


        public void ClearCart(int userId)
        {
            if (cartStorage.ContainsKey(userId))
            {
                cartStorage[userId].Clear();
                WriteJsonCartData();
            }
        }

        public void RemoveCartItem(int userId, int itemIndex)
        {
            if (cartStorage.ContainsKey(userId) && itemIndex >= 0 && itemIndex < cartStorage[userId].Count)
            {
                cartStorage[userId].RemoveAt(itemIndex);
                WriteJsonCartData();
            }
        }
        public List<CartItem> GetCartItems(int userId)
        {
            return _cartItems.Where(item => item.UserId == userId).ToList();
        }
    }
}
