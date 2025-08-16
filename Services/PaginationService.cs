using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
    public class PaginationService<T> where T : class
    {
        private readonly TestDbContext _ctx;

        public PaginationService(TestDbContext ctx) 
        {
            _ctx = ctx;
        }

        public Paginacao<T> ListItems(IQueryable<T> query, int page, int pageSize = 10)
        {
            var skip = (page - 1) * pageSize;
            var items = query
                .Skip(skip)
                .Take(pageSize)
                .ToList();
            var totalCount = query.Count();
            var hasNext = totalCount > skip + pageSize;
            return new Paginacao<T>(items, totalCount, hasNext);
        }

    }
}
