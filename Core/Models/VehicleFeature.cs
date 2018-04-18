using System.ComponentModel.DataAnnotations.Schema;

namespace Vega.Core.Models
{
    [Table("VehicleFeatures")]
    public class VehicleFeature
    {
        public int VehicleId { get; set; }
        public int FeatureId { get; set; }
        public Vehicle Vehicle { get; set; }
        public Features Feature { get; set; }
    }
}