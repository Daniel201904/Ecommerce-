using E_Commerce.Models;
namespace E_Commerce.Repositories.Interfaces
{
    public interface IImagenProducto
    {
        Task<List<ImagenProducto>> GetImagenProducto();
        Task<bool> PostImagenProducto(ImagenProducto imagenProducto);
    }
}
