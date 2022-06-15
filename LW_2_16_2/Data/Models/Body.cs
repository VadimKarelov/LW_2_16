using System;
using System.Collections.Generic;

namespace LW_2_16_2.Models
{
    public partial class Body
    {
        public Body()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public int Id { get; set; }
        public string BodyTitle { get; set; } = null!;
        public float BodySquare { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }

        public override string ToString()
        {
            return BodyTitle;
        }
    }
}
