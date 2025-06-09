namespace InventoryManagement.Model
{
    public class Product
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public Product() { }

        public Product(string productCode, string productName, string category, int quantity, decimal unitPrice)
        {
            ProductCode = productCode;
            ProductName = productName;
            Category = category;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
    }
}

