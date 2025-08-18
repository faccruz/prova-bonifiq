using ProvaPub.Payments;

namespace ProvaPub.Pagamentos.Estrategias
{
    public class BoletoPayment : IPaymentMethod
    {
        public string PaymentMethodName => "boleto";
        public async Task ProccessPayment(decimal value, int customerId)
        {
            // Implementação do pagamento via Boleto
            await Task.Delay(100); // Simula um processamento assíncrono
            Console.WriteLine($"Processando pagamento via Boleto para o cliente {customerId} no valor de {value:C}");
        }
    }
}
