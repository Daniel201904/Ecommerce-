using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    public class PedidosRepository : IPedidos
    {
        private readonly E_commerceContext context;

        public PedidosRepository(E_commerceContext context)
        {
            this.context = context;
        }

        public async Task<List<Pedidos>> GetPedidos()
        {
            var data = await context.Pedidos.ToListAsync();
            return data;
        }

        public async Task<bool> PostPedidos(Pedidos pedidos)
        {
            await context.Pedidos.AddAsync(pedidos);
            await context.SaveAsync();
            return true;
        }
    }
}
