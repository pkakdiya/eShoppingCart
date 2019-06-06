using eShoppingcart.Model;
using System.Collections.Generic;

namespace eShoppingcart.Interface
{
    public interface IPurchaseOrder
    {
        bool AddProductToPurchaseOrder(ProductPurchaseOrder product);

        bool RemoveProductFromPurchaseOrder(ProductPurchaseOrder product, bool removeAll = true);

        double TotalAmountOfOrder { get; }

        double SavedAmountOfOrder { get; }

        List<ProductPurchaseOrder> GetProductPurchaseList();

        List<Product> GetAnyPromotionalOfferFreeProduct();

        List<Product> GetPurchasedProducts();

        void PlaceOrder();
    }
}
