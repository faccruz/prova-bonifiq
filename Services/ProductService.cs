using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
	public class ProductService
	{
		private readonly TestDbContext _ctx;
		private readonly PaginationService<Product> _paginationService;

        public ProductService(TestDbContext ctx, PaginationService<Product> paginationService)
		{
			_ctx = ctx;
			_paginationService = paginationService;
        }

		public Paginacao<Product>  ListProducts(int page)
		{
			return _paginationService.ListItems(_ctx.Products, page);
        }

	}
}
