using System.Threading.Tasks;
using Vega.Core.Models;

namespace Vega.Core
{
    public interface IVehicleRepository
    {
            Task<Vehicle> GetVehicle(int Id, bool includeRelated = true);
            
            void  Add(Vehicle Vehicle);
            void Remove(Vehicle vehicle);
    }
    
}