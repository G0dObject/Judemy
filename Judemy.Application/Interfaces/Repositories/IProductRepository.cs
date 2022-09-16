using Judemy.Application.Common.Entity.Product;

namespace Judemy.Application.Interfaces.Repositories
{
	public interface IProductRepository
	{
		public Task<ICollection<GetProductMenu>> GetMenu();
		public Task RemoveAll();
	}
}
