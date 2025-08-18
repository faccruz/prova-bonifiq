using ProvaPub.Payments;

namespace ProvaPub.Pagamentos.Estrategias
{
    public class PixPayment : IPaymentMethod
    {
        public string PaymentMethodName => "pix";
        public async Task ProccessPayment(decimal value, int customerId)
        {
            // Implementação do pagamento via Pix
            await Task.Delay(100); // Simula um processamento assíncrono
            Console.WriteLine($"Processando pagamento via Pix para o cliente {customerId} no valor de {value:C}");
        }
    }    
}
