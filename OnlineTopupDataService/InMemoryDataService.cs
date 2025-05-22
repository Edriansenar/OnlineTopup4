using OnlineTopupDataService;
using OnlineTopupCommon;
using System;
using System.Collections.Generic;

namespace OnlineTopupDataService
{
    public class InMemoryDataService : ITopupDataService
    {
        List<UserAccount> accounts = new List<UserAccount>();

        public InMemoryDataService()
        {
            CreateDummyUserAccounts();
        }

        private void CreateDummyUserAccounts()
        {
            accounts.Add(new UserAccount { User = "Yanne", Pass = "12345" });
            accounts.Add(new UserAccount { User = "GGG", Pass = "123" });
            accounts.Add(new UserAccount { User = "test", Pass = "12345" });
            accounts.Add(new UserAccount { User = "admin", Pass = "1234" });
        }

        public void CreateAccount(UserAccount userAccount)
        {
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
    }
}
