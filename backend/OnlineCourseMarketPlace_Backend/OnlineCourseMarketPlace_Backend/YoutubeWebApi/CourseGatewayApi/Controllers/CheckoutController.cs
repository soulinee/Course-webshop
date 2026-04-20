using CourseGatewayApi.Contracts;
using CourseGatewayApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;

namespace CourseGatewayApi.Controllers
{
    [ApiController]
    [Route("api/checkout")]
    public class CheckoutController : ControllerBase
    {  
        private readonly IEnrollmentService _enrollmentService;

        public CheckoutController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        [HttpPost]
        public ActionResult CreateCheckoutSession([FromBody] CheckoutRequest request)
        {
            // For school project this can be ultra simple:
            var lineItems = request.Items.Select(item => new SessionLineItemOptions
            {
                Quantity = 1,
                PriceData = new SessionLineItemPriceDataOptions
                {
                    Currency = "eur",
                    UnitAmount = (long)(item.Price * 100), // 32.99 -> 3299
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = item.Title
                    }
                }
            }).ToList();

            var options = new SessionCreateOptions
            {
                Mode = "payment",
                LineItems = lineItems,
                SuccessUrl = "http://localhost:5173/checkout/success",
                CancelUrl = "http://localhost:5173/checkout/cancel"
            };

            var service = new SessionService();
            var session = service.Create(options);

            return Ok(new { url = session.Url });
        }

        [HttpPost("confirm")]
        public async Task<IActionResult> ConfirmPayment(
            [FromBody] ConfirmCheckoutRequest request)
        {
            foreach (var courseId in request.CourseIds)
            {
                var enrollmentRequest = new EnrollmentRequestContract(
                    request.UserId,
                    courseId
                );

                await _enrollmentService.EnrollAsync(enrollmentRequest);
            }

            return Ok();
        }






























    }
}
