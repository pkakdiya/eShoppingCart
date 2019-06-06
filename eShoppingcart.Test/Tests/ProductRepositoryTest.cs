using System;
using eShoppingcart.Interface;
using eShoppingcart.Model;
using eShoppingcart.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eshoppingcart.RepositoryTest
{
    [TestClass]
    public class ProductRepositoryTest
    {
        IProduct _productRepo;

        [TestInitialize]
        public void SetUp()
        {
            _productRepo = new ProductRepository(new eShoppingcart.DataAccess.DataAccess());
        }

        [TestMethod]
        public void AddProduct_With_Not_Null_Product()
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
            Assert.IsTrue(_productRepo.GetAllProducts().Count > 0);
        }

        [TestMethod]
        public void UpdateProduct_Remove_Discount()
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
            Assert.IsTrue(_productRepo.GetAllProducts()[0].Discount == 0 && _productRepo.GetAllProducts()[0].DiscountedPrice == 300);
        }

        [TestMethod]
        public void UpdateProduct_Check_DiscountedPrice()
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
            var productList = _productRepo.GetAllProducts();
            Assert.IsTrue(productList[0].DiscountedPrice < productList[0].OriginalPrice);
        }

        [TestMethod]
        public void DeleteProduct_Check_With_Products()
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
            _productRepo.DeleteProduct(product.ProductId);
            var productList = _productRepo.GetAllProducts();
            Assert.IsTrue(productList.Count == 0);
        }
    }
}
