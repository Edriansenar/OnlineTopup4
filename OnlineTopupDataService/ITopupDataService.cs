using OnlineTopupCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OnlineTopupCommon.UserAccount;

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
        
        void ClearCart(int userId);
        void RemoveCartItem(int userId, int itemIndex);
        List<CartItem> GetCartItems(int userId);


    }
}

