using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTopup
{
    internal class OnlineTopupBusinessLogic
    {

        public static List<string> AddToCart(string gameName, int userChoice, List<string> cart)
        {
            string[] options = new string[] { "50", "100", "500", "5,000", "10,000" };
            if (userChoice >= 1 && userChoice <= options.Length)
            {
                string selectedOption = $"{gameName}: {options[userChoice - 1]}";
                cart.Add(selectedOption);
            }
            return cart;
        }

        public static List<string> RemoveFromCart(int index, List<string> cart)
        {
            if (index >= 0 && index < cart.Count)
            {
                cart.RemoveAt(index);
            }
            return cart;
        }

        public static string ProcessCheckout(List<string> cart, int userId, string paymentMethod)
        {
            return $"Checkout complete!\nYou have successfully paid using {paymentMethod}.\nItems:\n- {string.Join("\n- ", cart)}";
        }
    }
}
    
