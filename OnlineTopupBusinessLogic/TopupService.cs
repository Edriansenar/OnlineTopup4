using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineTopupCommon;
using OnlineTopupDataService;


namespace OnlineTopupBusinessLogic
{
    namespace OnlineTopupBusinessLogic
    {
        public class TopupService
        {
            public ITopupDataService dataService;

            public TopupService(ITopupDataService dataService)
            {
                this.dataService = dataService;
            }

            public bool ValidateAccount(string username, string password)
            {
                var allAccounts = dataService.GetAccounts();
                return allAccounts.Any(acc => acc.User == username && acc.Pass == password);
            }

            public void CreateAccount(UserAccount userAccount)
            {
                dataService.CreateAccount(userAccount);
            }

            public UserAccount GetAccountByUsername(string username)
            {
                return dataService.GetAccountByUsername(username);
            }
        }
    }
}