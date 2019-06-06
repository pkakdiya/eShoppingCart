using System;
using System.Collections.Generic;
using System.Text;

namespace eShoppingcart.Model
{
    public class ProductPurchaseOrder
    {
        public Product Product { get; set; }

        public int Quantity { get; set; } = 1;
    }
}
