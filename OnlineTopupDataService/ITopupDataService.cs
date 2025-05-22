using OnlineTopupCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTopupDataService
{
    public interface ITopupDataService
    {
        public List<UserAccount> GetAccounts();
        public void CreateAccount(UserAccount topupAccount);
        public void UpdateAccount(UserAccount topupAccount);
        public void RemoveAccount(UserAccount topupAccount);
    }
}

