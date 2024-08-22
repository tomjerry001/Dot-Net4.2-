using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System.Model
{
    public class Inventory
    {
        // field
        private int ProductCode;

        public string ProductName {  get; set; }    

        public string Category { get; set; }    

        public int Quantity { get; set; }    

        public int UnitPrice { get; set; }

        // def constructor
        public Inventory()
        {
            
        }

        // parameterized constructor
        public Inventory(string productName, string category, int quantity, int unitPrice)
        {
            ProductName = productName;
            Category = category;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
    }
}
