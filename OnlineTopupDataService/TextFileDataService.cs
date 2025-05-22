using OnlineTopupCommon;
using OnlineTopupDataService;
using System;

namespace OnlineTopupDataService
{
    public class TextFileDataService : ITopupDataService
    {
        string filePath = "useraccounts.txt";
        List<UserAccount> userAccounts = new List<UserAccount>();

        public TextFileDataService()
        {
            GetDataFromFile();
        }

        private void GetDataFromFile()
        {
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "");
                return;
            }

            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var parts = line.Split('|');

                if (parts.Length >= 2)
                {
                    userAccounts.Add(new UserAccount
                    {
                        User = parts[0],
                        Pass = parts[1]
                    });
                }
            }
        }

        private void WriteDataToFile()
        {
            var lines = new string[userAccounts.Count];

            for (int i = 0; i < userAccounts.Count; i++)
            {
                lines[i] = $"{userAccounts[i].User}|{userAccounts[i].Pass}";
            }

            File.WriteAllLines(filePath, lines);
        }

        public int FindIndex(UserAccount account)
        {
            for (int i = 0; i < userAccounts.Count; i++)
            {
                if (userAccounts[i].User == account.User)
                {
                    return i;
                }
            }

            return -1;
        }

        public List<UserAccount> GetAccounts()
        {
            return userAccounts;
        }

        public void CreateAccount(UserAccount userAccount)
        {
            var newLine = $"{userAccount.User}|{userAccount.Pass}";
            File.AppendAllText(filePath, newLine + Environment.NewLine);
            userAccounts.Add(userAccount); // Update in-memory list too
        }

        public void UpdateAccount(UserAccount account)
        {
            int index = FindIndex(account);
            if (index != -1)
            {
                userAccounts[index].Pass = account.Pass;
                WriteDataToFile();
            }
        }

        public void RemoveAccount(UserAccount account)
        {
            int index = FindIndex(account);
            if (index != -1)
            {
                userAccounts.RemoveAt(index);
                WriteDataToFile();
            }
        }
    }
}

