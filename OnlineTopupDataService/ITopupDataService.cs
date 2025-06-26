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
        List<UserAccount> GetAccounts();
        UserAccount GetAccountByUsername(string username);
        void CreateAccount(UserAccount topupAccount);
        void UpdateAccount(UserAccount topupAccount);
        void RemoveAccount(UserAccount topupAccount);


        void AddCartItem(int userId, string gameName, string amount);
        List<(string GameName, string Amount)> GetCartItems(int userId);
        void ClearCart(int userId);

        void RemoveCartItem(int userId, int itemIndex);



    }
}

