namespace EFCodeFirstAssignment1.Model
{
    public class Order
    {
        //OrderID, CustomerID, OrderDate, TotalAmount
        public int OrderID { get; set; }
        public int? CustomerID {  get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? TotalAmount {  get; set; }

    }
}
