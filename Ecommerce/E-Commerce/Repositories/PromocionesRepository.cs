using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    public class PromocionesRepository : IPromociones
    {
        private readonly E_commerceContext context;

        public PromocionesRepository(E_commerceContext context)
        {
            this.context = context;
        }

        public async Task<List<Promociones>> GetPromociones()
        {
            var data = await context.Promociones.ToListAsync();
            return data;
        }

        public async Task<bool> PostPromociones(Promociones promociones)
        {
            await context.Promociones.AddAsync(promociones);
            await context.SaveAsync();
            return true;
        }
    }
}
