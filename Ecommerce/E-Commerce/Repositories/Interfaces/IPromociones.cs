using E_Commerce.Models;
namespace E_Commerce.Repositories.Interfaces
{
    public interface IPromociones
    {
        Task<List<Promociones>> GetPromociones();
        Task<bool> PostPromociones(Promociones promociones);
    }
}
