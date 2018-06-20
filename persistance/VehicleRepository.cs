using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vega.Core;
using Vega.Core.Models;

namespace Vega.persistance
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VegaDbContext context;
        public VehicleRepository(VegaDbContext context)
        {
            this.context = context;

        }
        public async Task<Vehicle> GetVehicle(int Id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await context.Vehicles.FindAsync(Id);
            return await context.Vehicles
            .Include(v => v.features)
            .ThenInclude(vf => vf.Feature)
            .Include(v => v.Model)
            .ThenInclude(m => m.Make)
            .SingleOrDefaultAsync(v => v.Id == Id);


        }
        public void Add(Vehicle vehicle)
        {
            context.Vehicles.Add(vehicle);
        }
        public void Remove(Vehicle vehicle)
        {
            context.Remove(vehicle);

        }
    }
}