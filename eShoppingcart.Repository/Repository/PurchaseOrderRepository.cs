using eShoppingcart.Interface;
using eShoppingcart.Model;
using System.Collections.Generic;
using System.Linq;

namespace eShoppingcart.Repository
{
    public class PurchaseOrderRepository : IPurchaseOrder
    {
        private DataAccess.DataAccess _dataAccess = null;
        private List<ProductPurchaseOrder> _productPurchaseList = null;
        private List<Product> _promotionalFreeProduct = null;
        private List<Product> _purchasedProducts = null;
        private double totalBillAmmountAfterDiscount;
        private double totalSavedAmmountOnBill;

        public PurchaseOrderRepository(DataAccess.DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            _productPurchaseList = new List<ProductPurchaseOrder>();
            _promotionalFreeProduct = new List<Product>();
            _purchasedProducts = new List<Product>();
        }

        public double TotalAmountOfOrder => totalBillAmmountAfterDiscount;

        public double SavedAmountOfOrder => totalSavedAmmountOnBill;

        public bool AddProductToPurchaseOrder(ProductPurchaseOrder product)
        {
            if (product != null)
            {
                var purchaseProduct = _productPurchaseList.Where(s => s.Product.ProductId == product.Product.ProductId).FirstOrDefault();
                if (purchaseProduct == null)
                    _productPurchaseList.Add(product);
                else
                    purchaseProduct.Quantity = product.Quantity;
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Product> GetAnyPromotionalOfferFreeProduct()
        {
            return _promotionalFreeProduct;
        }

        public List<ProductPurchaseOrder> GetProductPurchaseList()
        {
            return _productPurchaseList;
        }

        public List<Product> GetPurchasedProducts()
        {
            return _purchasedProducts;
        }

        public void PlaceOrder()
        {
            totalBillAmmountAfterDiscount = 0;
            totalSavedAmmountOnBill = 0;

            foreach (var productPurchase in _productPurchaseList)
            {
                totalBillAmmountAfterDiscount += productPurchase.Product.DiscountedPrice * productPurchase.Quantity;
                totalSavedAmmountOnBill += productPurchase.Product.SavedAmount * productPurchase.Quantity;
                _purchasedProducts.AddRange(AddPurchasedProducts(productPurchase));
                _promotionalFreeProduct.AddRange(ApplyPromotionalOffer(productPurchase));
            }
        }

        public bool RemoveProductFromPurchaseOrder(ProductPurchaseOrder product, bool removeAll = true)
        {
            if (removeAll)
            {
                var purchaseProduct = _productPurchaseList.Where(s => s.Product.ProductId == product.Product.ProductId).FirstOrDefault();
                if (purchaseProduct != null)
                  return  _productPurchaseList.Remove(purchaseProduct);
            }
            else
            {
                var purchaseProduct = _productPurchaseList.Where(s => s.Product.ProductId == product.Product.ProductId).FirstOrDefault();
                bool isRemoved = false;
                if (purchaseProduct != null)
                {
                    purchaseProduct.Quantity = product.Quantity;
                    isRemoved = false;
                }
                return isRemoved;
            }
            return true;
        }

        private List<Product> ApplyPromotionalOffer(ProductPurchaseOrder productPurchase)
        {
            List<Product> _products = new List<Product>();

            if (productPurchase.Product.HasAnyPromotionalOffer)
            {
                switch (productPurchase.Product.PromotionalOffer)
                {
                    case PromotionalOffer.ByTwoGetOneFree:
                        {
                            int freeProductCount = productPurchase.Quantity / 2;

                            if (freeProductCount > 0)
                            {
                                for (int i = 0; i < freeProductCount; i++)
                                {
                                    _products.Add(productPurchase.Product.Clone);
                                }
                            }
                        }
                        break;
                    default:
                        break;

                }
            }

            return _products;
        }

        private List<Product> AddPurchasedProducts(ProductPurchaseOrder productPurchase)
        {
            List<Product> _products = new List<Product>();

            for (int i = 0; i < productPurchase.Quantity; i++)
            {
                _products.Add(productPurchase.Product.Clone);
            }

            return _products;
        }
    }
}
