using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MomAndPopShop.Models;
using Stripe;
using Stripe.Checkout;

namespace MomAndPopShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutSessionController : ControllerBase
    {
        public IActionResult CreateCheckoutSession(Cart cart)
        {
            var domain = "http://localhost:44416";
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
                {
                    "card",
                },
                LineItems = cart.Items.Select(item => new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = item.PopcornItem.Name,
                        },
                        UnitAmount = (long)item.Cost * 100,
                    },
                    Quantity = item.Quantity,
                }).ToList(),
                PaymentMethodOptions = new SessionPaymentMethodOptionsOptions
                {
                    Card = new SessionPaymentMethodOptionsCardOptions(),
                },

                Mode = "payment",
                SuccessUrl = domain + "/success.html",
                CancelUrl = domain + "/cancel.html",
            };
            var service = new SessionService();
            Session session = service.Create(options);

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }
    }
}
