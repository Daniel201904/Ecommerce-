using E_Commerce.Models;
namespace E_Commerce.Repositories.Interfaces
{
    public interface ICategoria
    {
        Task<List<Categoria>> GetCategoria();
        Task<bool> PostCategoria(Categoria categoria);
    }
}
