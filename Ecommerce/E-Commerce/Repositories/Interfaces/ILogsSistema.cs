﻿using E_Commerce.Models;

namespace E_Commerce.Repositories.Interfaces
{
    public interface ILogsSistema
    {
        Task<List<LogsSistema>> GetLogsSistema();
        Task<bool> PostLogsSistema(LogsSistema logsSistema);
    }
}
