using LW_2_16_2.Data.Repository;
using LW_2_16_2.Models;

namespace LW_2_16_2.Forms.AdminWindow.TableItems
{
    internal class VehicleTableItem
    {
        public int ID { get; set; }
        public string VehicleTitle { get; set; }
        public string VehicleBrandTitle { get; set; }
        public string VehicleBodyTitle { get; set; }

        public VehicleTableItem(Vehicle vehicle)
        {
            ID = vehicle.Id;
            VehicleTitle = vehicle.VehicleTitle;

            using (BrandRepository rep = new BrandRepository())
            {
                VehicleBrandTitle = rep.Get(vehicle.VehicleBrandId).BrandTitle;
            }

            using (BodyRepository rep = new BodyRepository())
            {
                VehicleBodyTitle = rep.Get(vehicle.VehicleBodyId).BodyTitle;
            }
        }
    }
}
