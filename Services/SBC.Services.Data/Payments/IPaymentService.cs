namespace SBC.Services.Data.Payments
{
    using SBC.Common;
    using SBC.Web.ViewModels.Payment;

    public interface IPaymentService
    {
        Result Create(PaymentIntentCreateRequest request);
    }
}
