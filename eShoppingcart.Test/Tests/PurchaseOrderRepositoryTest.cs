using System;
using eShoppingcart.DataAccess;
using eShoppingcart.Interface;
using eShoppingcart.Model;
using eShoppingcart.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eshoppingcart.RepositoryTest
{
    [TestClass]
    public class PurchaseOrderRepositoryTest
    {
        IPurchaseOrder purchaseOrderRepo;

        [TestInitialize]
        public void SetUp()
        {
            purchaseOrderRepo = new PurchaseOrderRepository(new DataAccess());
        }

        [TestMethod]
        public void AddProductToPurchaseOrder_Where_ProductPurchase_IS_NULL()
        {
            Assert.IsFalse(purchaseOrderRepo.AddProductToPurchaseOrder(null));
        }

        [TestMethod]
        public void AddProductToPurchaseOrder_Where_ProductPurchase_IS_NOT_NULL()
        {
            var productPurchaseOrder = GetMockPurchaseProductOrder();
            Assert.IsTrue(purchaseOrderRepo.AddProductToPurchaseOrder(productPurchaseOrder));
        }

        [TestMethod]
        public void RemoveProductFromPurchaseOrder_RemoveAll()
        {
            var productPurchaseOrder = GetMockPurchaseProductOrder();
            Assert.IsTrue(purchaseOrderRepo.RemoveProductFromPurchaseOrder(productPurchaseOrder, true));
        }

        [TestMethod]
        public void RemoveProductFromPurchaseOrder_Remove()
        {
            var productPurchaseOrder = GetMockPurchaseProductOrder();
            purchaseOrderRepo.AddProductToPurchaseOrder(productPurchaseOrder);
            var previousQuantity = productPurchaseOrder.Quantity;

            productPurchaseOrder.Quantity = productPurchaseOrder.Quantity - 1;
            purchaseOrderRepo.RemoveProductFromPurchaseOrder(productPurchaseOrder, false);

            Assert.IsTrue(previousQuantity > productPurchaseOrder.Quantity);
        }

        [TestMethod]
        public void PlaceOrder_Without_PromotionalOffer()
        {
            var productPurchaseOrder = GetMockPurchaseProductOrder();
            purchaseOrderRepo.AddProductToPurchaseOrder(productPurchaseOrder);
            purchaseOrderRepo.PlaceOrder();
            Assert.IsTrue(purchaseOrderRepo.GetPurchasedProducts().Count == 2);
        }

        [TestMethod]
        public void PlaceOrder_With_PromotionalOffer()
        {
            var productPurchaseOrder = GetMockPurchaseProductOrder();
            purchaseOrderRepo.AddProductToPurchaseOrder(productPurchaseOrder);
            purchaseOrderRepo.PlaceOrder();
            Assert.IsTrue(purchaseOrderRepo.GetPurchasedProducts().Count == 2 && purchaseOrderRepo.GetAnyPromotionalOfferFreeProduct().Count == 1);
        }

        #region Test Data Methods

        private ProductPurchaseOrder GetMockPurchaseProductOrder()
        {
            ProductPurchaseOrder productPurchaseOrder = new ProductPurchaseOrder()
            {
                Product = new Product()
                {
                    Category = "Computer Accessaries",
                    Discount = 10,
                    Name = "Wireless Mouse",
                    ProductId = 1,
                    OriginalPrice = 300,
                    HasAnyPromotionalOffer = true,
                    PromotionalOffer = PromotionalOffer.ByTwoGetOneFree
                },
                Quantity = 2
            };
            return productPurchaseOrder;
        }

        #endregion
    }
}
