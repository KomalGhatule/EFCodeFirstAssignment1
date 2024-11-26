namespace EFCodeFirstAssignment1.Model
{
    public class OrderHistory
    {
        //OrderHistoryID, ProductID, Quantity, UnitPrice
        public int OrderHistoryID {  get; set; }
        public int? ProductID { get; set; }
        public int? Quantity { get; set; }
        public Decimal? UnitPrice { get; set; }

    }
}
