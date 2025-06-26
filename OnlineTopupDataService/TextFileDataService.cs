using OnlineTopupCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace OnlineTopupDataService
{
    public class TextFileDataService : ITopupDataService
    {
        string userFilePath = "useraccounts.txt";
        string cartFilePath = "cartitems.json";

        List<UserAccount> userAccounts = new();
        Dictionary<int, List<(string GameName, string Amount)>> cartStorage = new();
        private int nextUserId = 1;

        public TextFileDataService()
        {
            LoadUsersFromFile();
            LoadCartFromFile();
            if (userAccounts.Any())
                nextUserId = userAccounts.Max(u => u.Id) + 1;
        }

        private void LoadUsersFromFile()
        {
            if (!File.Exists(userFilePath)) File.WriteAllText(userFilePath, "");

            var lines = File.ReadAllLines(userFilePath);
            foreach (var line in lines)
            {
                var parts = line.Split('|');
                if (parts.Length >= 3 && int.TryParse(parts[0], out int id))
                {
                    userAccounts.Add(new UserAccount
                    {
                        Id = id,
                        User = parts[1],
                        Pass = parts[2]
                    });
                }
            }
        }

        private void SaveUsersToFile()
        {
            var lines = userAccounts.Select(u => $"{u.Id}|{u.User}|{u.Pass}").ToArray();
            File.WriteAllLines(userFilePath, lines);
        }

        private void LoadCartFromFile()
        {
            if (!File.Exists(cartFilePath)) File.WriteAllText(cartFilePath, "{}");
            string json = File.ReadAllText(cartFilePath);
            cartStorage = JsonSerializer.Deserialize<Dictionary<int, List<(string, string)>>>(json)
                          ?? new();
        }

        private void SaveCartToFile()
        {
            string json = JsonSerializer.Serialize(cartStorage, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(cartFilePath, json);
        }

        public void CreateAccount(UserAccount userAccount)
        {
            userAccount.Id = nextUserId++;
            userAccounts.Add(userAccount);
            SaveUsersToFile();
        }

        public List<UserAccount> GetAccounts() => userAccounts;

        public void UpdateAccount(UserAccount account)
        {
            var existing = userAccounts.FirstOrDefault(u => u.Id == account.Id);
            if (existing != null)
            {
                existing.Pass = account.Pass;
                SaveUsersToFile();
            }
        }

        public void RemoveAccount(UserAccount account)
        {
            userAccounts.RemoveAll(u => u.Id == account.Id);
            SaveUsersToFile();
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
                cartStorage[userId] = new();
            cartStorage[userId].Add((gameName, amount));
            SaveCartToFile();
        }

        public List<(string GameName, string Amount)> GetCartItems(int userId)
        {
            return cartStorage.TryGetValue(userId, out var items) ? new(items) : new();
        }

        public void ClearCart(int userId)
        {
            if (cartStorage.ContainsKey(userId))
            {
                cartStorage[userId].Clear();
                SaveCartToFile();
            }
        }

        public void RemoveCartItem(int userId, int itemIndex)
        {
            if (cartStorage.ContainsKey(userId) && itemIndex >= 0 && itemIndex < cartStorage[userId].Count)
            {
                cartStorage[userId].RemoveAt(itemIndex);
                SaveCartToFile();
            }
        }
    }
}
