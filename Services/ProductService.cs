using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
	public class ProductService
	{
		TestDbContext _ctx;

		public ProductService(TestDbContext ctx)
		{
			_ctx = ctx;
		}

		public ProductList  ListProducts(int page)
		{
			int pageSize = 10;

			var skip = (page - 1) * pageSize;

			var products = _ctx.Products
				.Skip(skip)
				.Take(pageSize)
				.ToList();

			var totalCount = _ctx.Products.Count();

			bool hasNext = totalCount > skip + pageSize;

            return new ProductList() {  HasNext=hasNext, TotalCount = totalCount, Products = products };
		}

	}
}
