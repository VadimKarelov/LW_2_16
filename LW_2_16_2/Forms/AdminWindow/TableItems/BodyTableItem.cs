using LW_2_16_2.Models;

namespace LW_2_16_2.Forms.AdminWindow.TableItems
{
    internal class BodyTableItem
    {
        public int ID { get; set; }
        public string BodyTitle { get; set; }
        public float BodySquare { get; set; }

        public BodyTableItem(Body body)
        {
            ID = body.Id;
            BodyTitle = body.BodyTitle;
            BodySquare = body.BodySquare;
        }
    }
}
