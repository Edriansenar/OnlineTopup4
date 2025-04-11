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
        }

    public bool ValidateTopupAccount(string userAccount, string pass)
    {
        foreach (var account in accounts)
        {
            if (account.User == userAccount && account.Pass == pass)
            {
                return true;
            }
        }
        return false;
    }


}
}
