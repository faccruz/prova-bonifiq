using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
	public class RandomService
	{
		int seed;
        bool numeroRepetido = false;
        TestDbContext _ctx;
		public RandomService()
        {
            var contextOptions = new DbContextOptionsBuilder<TestDbContext>()
    .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Teste;Trusted_Connection=True;")
    .Options;
            

            _ctx = new TestDbContext(contextOptions);
        }
        public async Task<int> GetRandom()
		{
            seed = Guid.NewGuid().GetHashCode();
            var number =  new Random(seed).Next(100);

            do  {
                
                number = new Random(seed).Next(100);
                numeroRepetido = _ctx.Numbers.Any(n => n.Number == number);
            } while (numeroRepetido);

           
            _ctx.Numbers.Add(new RandomNumber() { Number = number });
            _ctx.SaveChanges();
			return number;
		}

	}
}
