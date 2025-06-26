using OnlineTopupDataService;
using OnlineTopupCommon;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineTopupDataService
{
    public class InMemoryDataService : ITopupDataService
    {
        private List<UserAccount> accounts = new List<UserAccount>();
        private Dictionary<int, List<(string GameName, string Amount)>> cartStorage = new();
        private int nextUserId = 1;

        public InMemoryDataService()
        {
            CreateDummyUserAccounts();
        }

        private void CreateDummyUserAccounts()
        {
            CreateAccount(new UserAccount { User = "Yanne", Pass = "12345" });
            CreateAccount(new UserAccount { User = "GGG", Pass = "123" });
            CreateAccount(new UserAccount { User = "test", Pass = "12345" });
            CreateAccount(new UserAccount { User = "admin", Pass = "1234" });
        }

        public void CreateAccount(UserAccount userAccount)
        {
            userAccount.Id = nextUserId++;
            accounts.Add(userAccount);
        }

        public List<UserAccount> GetAccounts()
        {
            return accounts;
        }

        public void RemoveAccount(UserAccount userAccount)
        {
            accounts.RemoveAll(acc => acc.User == userAccount.User);
        }

        public void UpdateAccount(UserAccount userAccount)
        {
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].User == userAccount.User)
                {
                    accounts[i].Pass = userAccount.Pass;
                }
            }
        }

        public UserAccount GetAccountByUsername(string username)
        {
            return accounts.FirstOrDefault(u => u.User == username);
        }

        public void AddCartItem(int userId, string gameName, string amount)
        {
            if (!cartStorage.ContainsKey(userId))
            {
                cartStorage[userId] = new List<(string, string)>();
            }
            cartStorage[userId].Add((gameName, amount));
        }

        public List<(string GameName, string Amount)> GetCartItems(int userId)
        {
            if (cartStorage.TryGetValue(userId, out var items))
            {
                return new List<(string, string)>(items);
            }
            return new List<(string, string)>();
        }

        public void ClearCart(int userId)
        {
            if (cartStorage.ContainsKey(userId))
            {
                cartStorage[userId].Clear();
            }
        }

        public void RemoveCartItem(int userId, int itemIndex)
        {
            if (cartStorage.ContainsKey(userId) && itemIndex >= 0 && itemIndex < cartStorage[userId].Count)
            {
                cartStorage[userId].RemoveAt(itemIndex);
            }
        }
    }
}
