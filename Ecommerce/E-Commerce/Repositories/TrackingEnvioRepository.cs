using E_Commerce.Models;
using E_Commerce.Context;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    public class TrackingEnvioRepository : ITrackingEnvio
    {
        private readonly E_commerceContext context;

        public TrackingEnvioRepository(E_commerceContext context) 
        {
            this.context = context;
        }

        public async Task<List<TrackingEnvio>> GetTrackingEnvio()
        {
            var data = await context.TrackingEnvio.ToListAsync();
            return data;
        }

        public async Task<bool> PostTrackingEnvio(TrackingEnvio trackingEnvio)
        {
            await context.TrackingEnvio.AddAsync(trackingEnvio);
            await context.SaveAsync();
            return true;
        }
    }
}
