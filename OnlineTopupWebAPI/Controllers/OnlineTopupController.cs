using Microsoft.AspNetCore.Mvc;
using OnlineTopupBusinessLogic;
using OnlineTopupCommon;
using OnlineTopupDataService;

namespace OnlineTopupWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ITopupDataService _dataService;

        public CartController()
        {
            _dataService = new DBDataService();
        }

        // GET: api/cart/user/1
        [HttpGet("user/{userId}")]
        public ActionResult<IEnumerable<CartItem>> GetCartItems(int userId)
        {
            var cart = new Cart(_dataService, userId);
            var items = cart.GetItems(); // returns List<CartItem>
            return Ok(items);
        }

        [HttpPost("add")]
        public ActionResult AddItem([FromBody] CartAddRequest request)
        {
            var cart = new Cart(_dataService, request.UserId);
            cart.AddToCart(request.GameName, request.OptionIndex);
            return Ok("Item added to cart.");
        }

        [HttpDelete("remove")]
        public ActionResult RemoveItem([FromBody] CartRemoveRequest request)
        {
            var cart = new Cart(_dataService, request.UserId);
            cart.RemoveFromCart(request.ItemIndex);
            return Ok("Item removed from cart.");
        }

        [HttpPatch("update")]
        public ActionResult UpdateCartItem([FromBody] CartUpdateRequest request)
        {
            var cart = new Cart(_dataService, request.UserId);
            cart.RemoveFromCart(request.ItemIndex);
            cart.AddToCart(request.GameName, request.NewOptionIndex);
            return Ok("Cart item updated.");
        }

        [HttpPost("checkout")]
        public ActionResult<CheckoutData> Checkout([FromBody] CheckoutRequest request)
        {
            var cart = new Cart(_dataService, request.UserId);
            var data = cart.GetCheckoutData(request.PaymentMethod);
            cart.ClearCart();
            return Ok(data);
        }

        [HttpDelete("clear/{userId}")]
        public ActionResult ClearCart(int userId)
        {
            var cart = new Cart(_dataService, userId);
            cart.ClearCart();
            return Ok("Cart cleared.");
        }
    }

    // Request Models
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

