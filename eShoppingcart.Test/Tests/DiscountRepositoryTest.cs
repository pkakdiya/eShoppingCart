using System;
using eShoppingcart.Interface;
using eShoppingcart.Model;
using eShoppingcart.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eshoppingcart.RepositoryTest
{
    [TestClass]
    public class DiscountRepositoryTest
    {

        IDiscount _discountRepo;
        IProduct _productRepo;

        [TestInitialize]
        public void SetUp()
        {
            var dataAccess = new eShoppingcart.DataAccess.DataAccess();
            _productRepo = new ProductRepository(dataAccess);
            _discountRepo = new DiscountRepository(dataAccess);
        }

        [TestMethod]
        public void RemoveDiscountFromProduct_With_AddProduct()
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
            _productRepo.AddProduct(product);
            _discountRepo.RemoveDiscountFromProduct(product.ProductId);
            var productList = _productRepo.GetAllProducts();
            Assert.IsTrue(productList[0].Discount == 0);
        }

        [TestMethod]
        public void AddDiscountToProduct_With_AddProduct()
        {
            var product = new Product()
            {
                Category = "Computer Accessaries",
                Discount = 0,
                Name = "Wireless Mouse",
                ProductId = 1,
                OriginalPrice = 300,
                HasAnyPromotionalOffer = true,
                PromotionalOffer = PromotionalOffer.ByTwoGetOneFree
            };
            _productRepo.AddProduct(product);
            _discountRepo.AddDisCountToProduct(10, product.ProductId);
            var productList = _productRepo.GetAllProducts();
            Assert.IsTrue(productList[0].Discount > 0);
        }
    }
}

