using OnlineTopupDataService;
using OnlineTopupCommon;
using System.Text.Json;
using System.Collections.Generic;

namespace OnlineTopupDataService
{
    public class JsonFileDataService : ITopupDataService
    {
        static List<UserAccount> userAccounts = new List<UserAccount>();
        static string jsonFilePath = "useraccounts.json";

        public JsonFileDataService()
        {
            ReadJsonDataFromFile();
        }

        private void ReadJsonDataFromFile()
        {
            if (!File.Exists(jsonFilePath))
            {
                File.WriteAllText(jsonFilePath, "[]");
            }

            string jsonText = File.ReadAllText(jsonFilePath);

            userAccounts = JsonSerializer.Deserialize<List<UserAccount>>(jsonText,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
        }

        private void WriteJsonDataToFile()
        {
            string jsonString = JsonSerializer.Serialize(userAccounts, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(jsonFilePath, jsonString);
        }

        private int FindAccountIndex(string username, string password)
        {
            for (int i = 0; i < userAccounts.Count; i++)
            {
                if (userAccounts[i].User == username && userAccounts[i].Pass == password)
                {
                    return i;
                }
            }

            return -1;
        }

        public void CreateAccount(UserAccount userAccount)
        {
            userAccounts.Add(userAccount);
            WriteJsonDataToFile();
        }

        public List<UserAccount> GetAccounts()
        {
            return userAccounts;
        }

        public void RemoveAccount(UserAccount userAccount)
        {
            var index = FindAccountIndex(userAccount.User, userAccount.Pass);
            if (index != -1)
            {
                userAccounts.RemoveAt(index);
                WriteJsonDataToFile();
            }
        }

        public void UpdateAccount(UserAccount userAccount)
        {
            var index = FindAccountIndex(userAccount.User, userAccount.Pass);
            if (index != -1)
            {
                userAccounts[index].User = userAccount.User;
                userAccounts[index].Pass = userAccount.Pass;
                WriteJsonDataToFile();
            }
        }
    }

}