using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Model
{
    public class Order
    {
        public int OrderID { get; set; }  // Assuming int identity primary key
        public string CustomerName { get; set; }
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        public Order() { }

        public Order(int orderId, string customerName, string productCode, int quantity, decimal totalPrice)
        {
            OrderID = orderId;
            CustomerName = customerName;
            ProductCode = productCode;
            Quantity = quantity;
            TotalPrice = totalPrice;
        }
    }
}
