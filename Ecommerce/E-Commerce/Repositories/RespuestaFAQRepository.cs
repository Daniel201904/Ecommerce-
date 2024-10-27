﻿using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    public class RespuestaFAQRepository : IRespuestaFAQ
    {
        private readonly E_commerceContext context;

        public RespuestaFAQRepository(E_commerceContext context)
        {
            this.context = context;
        }

        public async Task<List<RespuestasFAQ>> GetRespuestasFAQ()
        {
            var data = await context.RespuestasFAQ.ToListAsync();
            return data;
        }

        public async Task<bool> PostRespuestaFAQ(RespuestasFAQ respuestasFAQ)
        {
            await context.RespuestasFAQ.AddAsync(respuestasFAQ);
            await context.SaveAsync();
            return true;
        }
    }
}
