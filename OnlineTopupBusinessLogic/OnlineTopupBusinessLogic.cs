using System;
using System.Collections.Generic;

namespace OnlineTopupBusinessLogic
{
    public class Cart
    {
        private List<string> items = new List<string>();

        private readonly string[] options = new string[] { "50", "100", "500", "5,000", "10,000" };

        public void AddToCart(string gameName, int userChoice)
        {
            if (userChoice >= 1 && userChoice <= options.Length)
            {
                string selectedOption = $"{gameName}: {options[userChoice - 1]}";
                items.Add(selectedOption);
            }
        }

        public void RemoveFromCart(int index)
        {
            if (index >= 0 && index < items.Count)
            {
                items.RemoveAt(index);
            }
        }

        public string ProcessCheckout(int userId, string paymentMethod)
        {
            if (items.Count == 0)
            {
                return "Your cart is empty. Add some items before checking out.";
            }

            return $"Checkout complete!\nUser ID: {userId}\nPayment method: {paymentMethod}\nItems:\n- {string.Join("\n- ", items)}";
        }

        public List<string> GetItems()
        {
            return new List<string>(items);
        }
    }
}

