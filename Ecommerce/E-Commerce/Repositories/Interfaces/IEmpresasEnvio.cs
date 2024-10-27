﻿using E_Commerce.Models;

namespace E_Commerce.Repositories.Interfaces
{
    public interface IEmpresasEnvio
    {
        Task<List<EmpresasEnvio>> GetEmpresasEnvios();

        Task<bool> PostEmpresasEnvios(EmpresasEnvio empresasEnvio);
    }
}