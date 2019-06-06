using System;
using System.Collections.Generic;
using System.Text;

namespace eShoppingcart.Interface
{
    public interface IDiscount
    {
        void AddDisCountToProduct(int percentage, double productId);

        void RemoveDiscountFromProduct(double productId);
    }
}
