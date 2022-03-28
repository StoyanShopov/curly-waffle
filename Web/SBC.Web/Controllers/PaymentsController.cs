namespace SBC.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SBC.Common;
    using SBC.Services.Data.Payments;
    using SBC.Web.ViewModels.Payment;
    using Stripe;

    public class PaymentsController : ApiController
    {
        private readonly IPaymentService paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            StripeConfiguration.ApiKey = "sk_test_51KiIAkHikRg6a9YedmQu2FnBO5o8en1nK3VhwzdSjoGVkoR8D7smJrUjVbhpV6gZhWZvA18mPw8W3G6RXULLGS0F00cOOKNwlI";
            this.paymentService = paymentService;
        }

        [Route("create-payment-intent")]
        public ActionResult Create(PaymentIntentCreateRequest request)
        {
            var payment = this.paymentService.Create(request);

            return this.GenericResponse(payment);
        }
    }
}