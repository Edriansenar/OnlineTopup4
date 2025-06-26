using System.Collections.Generic;
using System.Linq;
using OnlineTopupDataService;

namespace OnlineTopupBusinessLogic
{
    public class Cart
    {
        private readonly ITopupDataService dataService;
        private readonly int userId;

        public Cart(ITopupDataService dataService, int userId)
        {
            this.dataService = dataService;
            this.userId = userId;
        }

        public void AddToCart(string gameName, int optionIndex)
        {
            string[] options = { "50", "100", "500", "5,000", "10,000" };

            if (optionIndex >= 1 && optionIndex <= options.Length)
            {
                string amount = options[optionIndex - 1];
                dataService.AddCartItem(userId, gameName, amount);
            }
        }

        public void ClearCart()
        {
            dataService.ClearCart(userId);
        }

        public bool IsCartEmpty()
        {
            return GetItems().Count == 0;
        }

        public List<string> GetItems()
        {
            var rawItems = dataService.GetCartItems(userId);
            return rawItems.Select(item => $"{item.GameName}: {item.Amount}").ToList();
        }

        public CheckoutData GetCheckoutData(string paymentMethod)
        {
            var rawItems = dataService.GetCartItems(userId);

            return new CheckoutData
            {
                UserId = userId,
                PaymentMethod = paymentMethod,
                Items = rawItems.Select(item => $"{item.GameName}: {item.Amount}").ToList()
            };
        }
        public void RemoveFromCart(int index)
        {
            dataService.RemoveCartItem(userId, index + 1); 
        }
    }

}



