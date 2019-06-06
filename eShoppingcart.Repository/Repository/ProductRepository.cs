using eShoppingcart.Interface;
using eShoppingcart.Model;
using System.Collections.Generic;
using System.Linq;

namespace eShoppingcart.Repository
{
    public class ProductRepository : IProduct
    {
        private DataAccess.DataAccess _dataAccess = null;

        public ProductRepository(DataAccess.DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public void AddProduct(Product product)
        {
            _dataAccess.AddProduct(product);
        }

        public void DeleteProduct(double productId)
        {
            _dataAccess.RemoveProduct(productId);
        }

        public List<Product> GetAllProducts()
        {
            return _dataAccess.GetProducts();
        }

        public List<Product> GetProductsByCategory(string category)
        {
            return _dataAccess.GetProducts().Where(s => s.Category == category).ToList();
        }

        public void UpdateProduct(Product product)
        {
            _dataAccess.UpdateProduct(product);
        }
    }
}
