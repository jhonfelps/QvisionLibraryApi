using System.Threading.Tasks;

namespace Core.Interfaces
{
    public  interface IUnitOfWork
	{
		ILibroRepository Libros { get; }
		Task<int> SaveAsync();
	}
}
