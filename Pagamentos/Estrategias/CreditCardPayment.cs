using ProvaPub.Payments;

namespace ProvaPub.Pagamentos.Estrategias
{
    public class CreditCardPayment : IPaymentMethod
    {
        public string PaymentMethodName => "creditcard";
        public async Task ProccessPayment(decimal value, int customerId)
        {
            // Implementação do pagamento via Cartão de Crédito
            await Task.Delay(100); // Simula um processamento assíncrono
            Console.WriteLine($"Processando pagamento via Cartão de Crédito para o cliente {customerId} no valor de {value:C}");
        }
    }
}
