﻿using E_Commerce.Models;

namespace E_Commerce.Repositories.Interfaces
{
    public interface IAuditorias
    {
        Task<List<Auditorias>> GetAuditorias();

        Task<bool> PostAuditorias(Auditorias audirorias);
    }
}