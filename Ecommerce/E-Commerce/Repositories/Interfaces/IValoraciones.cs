using E_Commerce.Models;
namespace E_Commerce.Repositories.Interfaces
{
    public interface IValoraciones
    {
        Task<List<Valoraciones>> GetValoraciones();
        Task<bool> PostValoraciones(Valoraciones valoraciones);
    }
}
