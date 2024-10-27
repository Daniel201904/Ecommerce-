﻿using E_Commerce.Models;
namespace E_Commerce.Repositories.Interfaces
{
    public interface IRol
    {
        Task<List<Rol>> GetRol();
        Task<bool> PostRol(Rol rol);
    }
}
