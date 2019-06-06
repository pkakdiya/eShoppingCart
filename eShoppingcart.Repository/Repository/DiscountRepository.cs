using eShoppingcart.Interface;
using System.Linq;

namespace eShoppingcart.Repository
{
    public class DiscountRepository : IDiscount
    {
        private DataAccess.DataAccess _dataAccess = null;

        public DiscountRepository(DataAccess.DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public void AddDisCountToProduct(int percentage, double productId)
        {
            var _product = _dataAccess.GetProducts().Where(s => s.ProductId == productId).FirstOrDefault();

            if (_product != null)
            {
                _product.Discount = percentage;
                _dataAccess.UpdateProduct(_product);
            }
        }

        public void RemoveDiscountFromProduct(double productId)
        {
            var _product = _dataAccess.GetProducts().Where(s => s.ProductId == productId).FirstOrDefault();

            if (_product != null)
            {
                _product.Discount = 0;
                _dataAccess.UpdateProduct(_product);
            }
        }
    }
}
