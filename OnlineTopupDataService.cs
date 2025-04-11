using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTopup
{
    public class OnlineTopupDataService
    {

        List<OnlineTopupCommon> accounts = new List<OnlineTopupCommon>();

        public OnlineTopupDataService()
        {
            CreateDummyBankAccounts();
        }
        private void CreateDummyBankAccounts()
        {
            OnlineTopupCommon account1 = new OnlineTopupCommon();
            account1.User = "Yanne";
            account1.Pass = "12345";

            accounts.Add(account1);

            OnlineTopupCommon account2 = new OnlineTopupCommon
            {
                User = "indaleen",
                Pass = "123",
            };

            accounts.Add(account2);

            accounts.Add(new OnlineTopupCommon
            {
                User = "maria123",
                Pass="admin",
            });

            accounts.Add(new OnlineTopupCommon
            {
                User = "ann123",
                Pass = "admin123",
            });
        }
        public bool ValidateTopupAccount(string userAccount, string userPass)
    {
        foreach (var account in accounts)
        {
            if (account.User == userAccount && account.Pass == userPass)
            {
                return true;
            }
        }
        return false;
    }


}
}
