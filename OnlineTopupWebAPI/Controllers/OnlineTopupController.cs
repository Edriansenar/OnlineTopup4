using Microsoft.AspNetCore.Mvc;
using OnlineTopup.OnlineTopupBusinessLogic;     // EmailService namespace
using OnlineTopup.OnlineTopupCommon;            // EmailSettings namespace if used anywhere
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
        private readonly EmailService _emailService;

        // Use DI to get data service and email service
        public CartController(ITopupDataService dataService, EmailService emailService)
        {
            _dataService = dataService;
            _emailService = emailService;
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

        // POST: api/cart/checkout
        [HttpPost("checkout")]
        public ActionResult<CheckoutData> Checkout([FromBody] CheckoutRequest request)
        {
            var cart = new Cart(_dataService, request.UserId);
            var data = cart.GetCheckoutData(request.PaymentMethod);

            // Clear cart (you already do this in original code)
            cart.ClearCart();

            // Send email confirmation using the injected EmailService.
            // EmailService.SendEmail(string accountNumber) uses EmailSettings.ToAddress from appsettings.json
            try
            {
                _emailService.SendEmail(data.UserId.ToString());
            }
            catch (Exception ex)
            {
                // Don't throw 500 if email fails; return a 200 with failure note or use 207/other logic
                // Here we include info for debugging and still return the checkout data.
                return StatusCode(500, new { message = "Checkout completed but email failed to send.", error = ex.Message, checkout = data });
            }

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
