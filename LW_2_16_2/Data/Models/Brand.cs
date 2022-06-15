using System;
using System.Collections.Generic;

namespace LW_2_16_2.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public int Id { get; set; }
        public string BrandTitle { get; set; } = null!;
        public string BrandCountry { get; set; } = null!;

        public virtual ICollection<Vehicle> Vehicles { get; set; }

        public override string ToString()
        {
            return BrandTitle;
        }
    }
}
