using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTopupCommon
{
    public class UserAccount
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public int UserId { get; set; }
        public string PaymentMethod { get; set; }
        public List<string> Items { get; set; }
        public string GameName { get; set; }
        public string Amount { get; set; }
        public DateTime DateAdded { get; set; }


    }
    public class CartItem
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string GameName { get; set; }
        public string Amount { get; set; }
        public DateTime DateAdded { get; set; }
    }
    public class CheckoutData
    {
        public int UserId { get; set; }
        public string PaymentMethod { get; set; }
        public List<string> Items { get; set; }
    }
}

