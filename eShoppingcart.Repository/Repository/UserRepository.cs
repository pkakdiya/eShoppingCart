using eShoppingcart.Interface;
using eShoppingcart.Model;
using System.Collections.Generic;

namespace eShoppingcart.Repository
{
    public class UserRepository : IUser
    {
        IPurchaseOrder _orderRepository = null;

        double _totalAmmount = 0;

        double _totalSavedAmmount = 0;

        public UserRepository(IPurchaseOrder purchaseOrder)
        {
            _orderRepository = purchaseOrder;
        }

        public double TotalBillAmount { get =>  _totalAmmount; }

        public double TotalSavedAmountOnBill { get => _totalSavedAmmount; }

        public void AddProductToShoppingCart(Product product, int quantity = 1)
        {
            ProductPurchaseOrder productPurchase = new ProductPurchaseOrder()
            {
                Product = product,
                Quantity = quantity
            };
            _orderRepository.AddProductToPurchaseOrder(productPurchase);
        }

        public List<Product> GetAnyPromotionalOfferFreeProduct()
        {
            return _orderRepository.GetAnyPromotionalOfferFreeProduct();
        }

        public void RemoveProductsFromShoppingCart(Product product, int quantity = 1, bool removeAll = false)
        {
            ProductPurchaseOrder productPurchase = new ProductPurchaseOrder()
            {
                Product = product,
                Quantity = quantity
            };
            _orderRepository.RemoveProductFromPurchaseOrder(productPurchase, removeAll);
        }

        public void PlaceOrderAndGenerateBill()
        {
            _orderRepository.PlaceOrder();
            _totalAmmount = _orderRepository.TotalAmountOfOrder;
            _totalSavedAmmount = _orderRepository.SavedAmountOfOrder;
        }

        public List<Product> GetPurchasedProducts()
        {
            return _orderRepository.GetPurchasedProducts();
        }
    }
}
