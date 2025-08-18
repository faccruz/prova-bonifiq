using ProvaPub.Payments;

namespace ProvaPub.Pagamentos.Estrategias
{
    public class PayPalPayment : IPaymentMethod
    {
        public string PaymentMethodName => "paypal";
        public async Task ProccessPayment(decimal value, int customerId)
        {
            // Implementação do pagamento via Cartão de Crédito
            await Task.Delay(100); // Simula um processamento assíncrono
            Console.WriteLine($"Processando pagamento via PayPal para o cliente {customerId} no valor de {value:C}");
        }
    }
}
