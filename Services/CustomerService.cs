using Microsoft.EntityFrameworkCore;
using ProvaPub.Interface;
using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
    public class CustomerService
    {
        private readonly TestDbContext _ctx;
        private readonly PaginationService<Customer> _paginationService;
        private readonly IDateTimeProvider _clock;

        public CustomerService(TestDbContext ctx, PaginationService<Customer> paginationService, IDateTimeProvider clock)
        {
            _ctx = ctx;
            _paginationService = paginationService;
            _clock = clock;
        }

        public Paginacao<Customer> ListCustomers(int page)
        {
            return _paginationService.ListItems(_ctx.Customers, page);
        }

        public async Task<bool> CanPurchase(int customerId, decimal purchaseValue)
        {
            if (customerId <= 0) throw new ArgumentOutOfRangeException(nameof(customerId));

            if (purchaseValue <= 0) throw new ArgumentOutOfRangeException(nameof(purchaseValue));

            var customer = await _ctx.Customers.Include(c => c.Orders).FirstOrDefaultAsync(c => c.Id == customerId);

            if (customer == null) throw new InvalidOperationException($"Customer Id {customerId} does not exists");

            var baseDate = _clock.UtcNow.AddMonths(-1);
            var ordersInMonth = await _ctx.Orders.CountAsync(o => o.CustomerId == customerId && o.OrderDate >= baseDate);
            if (ordersInMonth > 0) return false;

            var now = _clock.UtcNow;
            if (now.Hour < 8 || now.Hour > 18 || now.DayOfWeek == DayOfWeek.Saturday || now.DayOfWeek == DayOfWeek.Sunday)
                return false;

            return true;
        }

    }
}
