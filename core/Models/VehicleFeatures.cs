
using System.ComponentModel.DataAnnotations.Schema;

namespace Vega.Core.Models
{
    [Table("VehicleFeatures")]
    public class VehicleFeatures
    {
        public int VehicleId { get; set; }
        public int FeatureId { get; set; }
        public Vehicle Vehicle { get; set; }
        public Feature Feature { get; set; }
    }
}