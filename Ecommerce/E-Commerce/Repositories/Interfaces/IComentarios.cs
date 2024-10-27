﻿using E_Commerce.Models;

namespace E_Commerce.Repositories.Interfaces
{
    public interface IComentarios
    {
        Task<List<Comentarios>> GetComentarios();
        Task<bool> PostComentarios(Comentarios comentarios);
    }
}