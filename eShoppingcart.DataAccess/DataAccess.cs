using eShoppingcart.Model;
using System.Collections.Generic;
using System.Linq;

namespace eShoppingcart.DataAccess
{
    public class DataAccess
    {
        private List<Product> list = new List<Product>();

        public List<Product> GetProducts()
        {
            return list;
        }

        public void AddProduct(Product product)
        {
            var _product = list.Where(s => s.ProductId == product.ProductId).FirstOrDefault();

            if (_product == null)
            {
                list.Add(product);
            }
        }

        public void UpdateProduct(Product product)
        {
            var _product = list.Where(s => s.ProductId == product.ProductId).FirstOrDefault();

            if (_product != null)
            {
                _product.Category = product.Category;
                _product.OriginalPrice = product.OriginalPrice;
                _product.Name = product.Name;
                _product.Discount = product.Discount;
            }
        }

        public void RemoveProduct(double productId)
        {
            var _product = list.Where(s => s.ProductId == productId).FirstOrDefault();

            if (_product != null)
            {
                list.Remove(_product);
            }
        }
    }
}
