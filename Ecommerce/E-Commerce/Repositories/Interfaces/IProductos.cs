﻿using E_Commerce.Models;

namespace E_Commerce.Repositories.Interfaces
{
    public interface IProductos
    {
        Task<List<Productos>> GetProductos();
        Task<bool> PostProductos(Productos productos);
    }
}
