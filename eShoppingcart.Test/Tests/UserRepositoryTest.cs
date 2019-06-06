using System;
using eShoppingcart.Interface;
using eShoppingcart.Model;
using eShoppingcart.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eshoppingcart.RepositoryTest
{
    [TestClass]
    public class UserRepositoryTest
    {
        IDiscount _discountRepo;
        IProduct _productRepo;
        IUser _userRepo;
        IPurchaseOrder _purchaseOrderRepo;

        [TestInitialize]
        public void SetUp()
        {
            var dataAccess = new eShoppingcart.DataAccess.DataAccess();
            _productRepo = new ProductRepository(dataAccess);
            _discountRepo = new DiscountRepository(dataAccess);
            _purchaseOrderRepo = new PurchaseOrderRepository(dataAccess);
            _userRepo = new UserRepository(_purchaseOrderRepo);
        }

        [TestMethod]
        public void AddProductToShoppingCart_Add_Product()
        {
            var product = new Product()
            {
                Category = "Computer Accessaries",
                Discount = 10,
                Name = "Wireless Mouse",
                ProductId = 1,
                OriginalPrice = 300,
                HasAnyPromotionalOffer = true,
                PromotionalOffer = PromotionalOffer.ByTwoGetOneFree
            };
            _userRepo.AddProductToShoppingCart(product);
            var productPurchaseList = _purchaseOrderRepo.GetProductPurchaseList();
            Assert.AreEqual(productPurchaseList.Count, 1);
        }

        [TestMethod]
        public void RemoveProductFromShoppingCart_Add_Product()
        {
            var product = new Product()
            {
                Category = "Computer Accessaries",
                Discount = 10,
                Name = "Wireless Mouse",
                ProductId = 1,
                OriginalPrice = 300,
                HasAnyPromotionalOffer = true,
                PromotionalOffer = PromotionalOffer.ByTwoGetOneFree
            };
            _userRepo.AddProductToShoppingCart(product);
            _userRepo.RemoveProductsFromShoppingCart(product);
            var productPurchaseList = _purchaseOrderRepo.GetProductPurchaseList();
            Assert.AreEqual(productPurchaseList.Count, 0);
        }
    }
}
