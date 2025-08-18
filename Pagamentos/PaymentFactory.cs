namespace ProvaPub.Payments
{
    public class PaymentFactory
    {
        private readonly IEnumerable<IPaymentMethod> _paymentMethods;

        public PaymentFactory(IEnumerable<IPaymentMethod> paymentMethods)
        {
            _paymentMethods = paymentMethods;
        }

        public IPaymentMethod GetPaymentMethod(string paymentMethodName)
        {
            var paymentMethod = _paymentMethods.FirstOrDefault(pm => pm.PaymentMethodName.Equals(paymentMethodName, StringComparison.OrdinalIgnoreCase));
            if (paymentMethod == null)
            {
                throw new ArgumentException($"Método '{paymentMethodName}' não é suportado.");
            }
            return paymentMethod;
        }
    }
}
