namespace ProvaPub.Payments
{
    public interface IPaymentMethod
    {
        string PaymentMethodName { get; }
        Task ProccessPayment(decimal value, int customerId);
    }
}
