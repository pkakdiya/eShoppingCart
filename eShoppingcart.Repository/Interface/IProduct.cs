using eShoppingcart.Model;
using System.Collections.Generic;

namespace eShoppingcart.Interface
{
    public interface IProduct
    {
        List<Product> GetAllProducts();

        List<Product> GetProductsByCategory(string category);

        void AddProduct(Product product);

        void DeleteProduct(double productId);

        void UpdateProduct(Product product);
    }
}
