using eShoppingcart.Model;
using System.Collections.Generic;

namespace eShoppingcart.Interface
{
    public interface IUser
    {
        void AddProductToShoppingCart(Product product, int quantity = 1);

        void RemoveProductsFromShoppingCart(Product product, int quantity = 1, bool removeAll = true);

        double TotalBillAmount { get; }

        double TotalSavedAmountOnBill { get;  }

        List<Product> GetPurchasedProducts();

        List<Product> GetAnyPromotionalOfferFreeProduct();

        void PlaceOrderAndGenerateBill();
    }
}
