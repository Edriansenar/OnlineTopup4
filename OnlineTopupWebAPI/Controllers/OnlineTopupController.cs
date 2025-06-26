using Microsoft.AspNetCore.Mvc;
using OnlineTopupBusinessLogic;
using OnlineTopupDataService;

namespace OnlineTopupWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly Cart cart;

        public CartController()
        {
            ITopupDataService dataService = new DBDataService();
            int testUserId = 1; 
            cart = new Cart(dataService, testUserId);
        }

        [HttpPatch("update")]
        public ActionResult UpdateCartItem([FromBody] CartUpdateRequest request)
        {
            cart.RemoveFromCart(request.ItemIndex);
            cart.AddToCart(request.GameName, request.NewOptionIndex);
            return Ok("Cart item updated.");
        }

        [HttpGet("user/{userId}")]
        public ActionResult<IEnumerable<string>> GetCartItems(int userId)
        {
            var items = cart.GetItems();
            return Ok(items);
        }

        [HttpPost("add")]
        public ActionResult AddItem([FromBody] CartAddRequest request)
        {
            cart.AddToCart(request.GameName, request.OptionIndex);
            return Ok("Item added to cart.");
        }

        [HttpDelete("remove")]
        public ActionResult RemoveItem([FromBody] CartRemoveRequest request)
        {
            cart.RemoveFromCart(request.ItemIndex);
            return Ok("Item removed from cart.");
        }

        [HttpPost("checkout")]
        public ActionResult<CheckoutData> Checkout([FromBody] CheckoutRequest request)
        {
            var data = cart.GetCheckoutData(request.PaymentMethod);
            cart.ClearCart();
            return Ok(data);
        }

        [HttpDelete("clear/{userId}")]
        public ActionResult ClearCart(int userId)
        {
            cart.ClearCart();
            return Ok("Cart cleared.");
        }
    }
    public class CartAddRequest
    {
        public int UserId { get; set; }
        public string GameName { get; set; }
        public int OptionIndex { get; set; }
    }

    public class CartRemoveRequest
    {
        public int UserId { get; set; }
        public int ItemIndex { get; set; }
    }

    public class CheckoutRequest
    {
        public int UserId { get; set; }
        public string PaymentMethod { get; set; }
    }
    public class CartUpdateRequest
    {
        public int UserId { get; set; }
        public int ItemIndex { get; set; }
        public string GameName { get; set; }
        public int NewOptionIndex { get; set; }
    }

}
