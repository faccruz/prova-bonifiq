using ProvaPub.Models;
using ProvaPub.Payments;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
	public class OrderService
	{
        TestDbContext _ctx;
		private readonly PaymentFactory _factory;

        public OrderService(TestDbContext ctx, PaymentFactory factory)
        {
            _ctx = ctx;
			_factory = factory;
        }

        public async Task<Order> PayOrder(string paymentMethod, decimal paymentValue, int customerId)
		{

			var payment = _factory.GetPaymentMethod(paymentMethod);

			await payment.ProccessPayment(paymentValue, customerId);

			var order = new Order
			{
				Value = paymentValue,
				CustomerId = customerId,
				OrderDate = DateTime.UtcNow // Salva a data como UTC
			};

			return await InsertOrder(order);
		}

		public async Task<Order> InsertOrder(Order order)
        {
			//Insere pedido no banco de dados
			return (await _ctx.Orders.AddAsync(order)).Entity;
        }
	}
}
