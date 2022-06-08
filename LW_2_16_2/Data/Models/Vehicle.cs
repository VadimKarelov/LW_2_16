using System;
using System.Collections.Generic;

namespace LW_2_16_2.Models
{
    public partial class Vehicle
    {
        public int Id { get; set; }
        public string VehicleTitle { get; set; } = null!;
        public int VehicleBodyId { get; set; }
        public int VehicleBrandId { get; set; }

        public virtual Body VehicleBody { get; set; } = null!;
        public virtual Brand VehicleBrand { get; set; } = null!;
    }
}
