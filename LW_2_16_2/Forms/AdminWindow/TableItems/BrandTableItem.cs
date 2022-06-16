using LW_2_16_2.Models;

namespace LW_2_16_2.Forms.AdminWindow.TableItems
{
    internal class BrandTableItem
    {
        public int ID { get; set; }
        public string BrandTitle { get; set; }
        public string BrandCountry { get; set; }

        public BrandTableItem(Brand brand)
        {
            ID = brand.Id;
            BrandTitle = brand.BrandTitle;
            BrandCountry = brand.BrandCountry;
        }
    }
}
