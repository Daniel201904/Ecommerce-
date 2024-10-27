﻿using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    public class ProductosRepository : IProductos
    {
        private readonly E_commerceContext context;

        public ProductosRepository(E_commerceContext context)
        {
            this.context = context;
        }

        public async Task<List<Productos>> GetProductos()
        {
            var data = await context.Productos.ToListAsync();
            return data;
        }

        public async Task<bool> PostProductos(Productos productos)
        {
            await context.Productos.AddAsync(productos);
            await context.SaveAsync();
            return true;
        }
    }
}
