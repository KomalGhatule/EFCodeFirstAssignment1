namespace EFCodeFirstAssignment1.Model
{
    public class Product
    {
        //ProductID, ProductName, Description, StockQuantity, CreatedDate
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public int? StockQuantity { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
