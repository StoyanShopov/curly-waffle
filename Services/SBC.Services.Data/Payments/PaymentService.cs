namespace SBC.Services.Data.Payments
{
    using SBC.Common;
    using SBC.Web.ViewModels.Payment;
    using Stripe;

    public class PaymentService : IPaymentService
    {
        public Result Create(PaymentIntentCreateRequest request)
        {
            var paymentIntentService = new PaymentIntentService();
            var paymentIntent = paymentIntentService.Create(new PaymentIntentCreateOptions
            {
                Amount = request.Items.Length,
                Currency = "eur",
                AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
                {
                    Enabled = true,
                },
            });

            var result = new { clientSecret = paymentIntent.ClientSecret };

            return new ResultModel(result);
        }
    }
}
