using System;

namespace eShoppingcart.Model
{
    public class Product
    {

        private double _savedAmmount = 0;

        private double _discountedPrice = 0;

        private double _originalPrice = 0;

        private int _discount = 0;

        public double ProductId { get; set; }

        public string Category { get; set; }

        public string Name { get; set; }

        public double OriginalPrice { get => _originalPrice; set => _originalPrice = value; }

        public int Discount { get => _discount; set => _discount = value; }

        public double DiscountedPrice
        {
            get
            {
                if (_discount > 0)
                {
                    _discountedPrice = _originalPrice - (_originalPrice * _discount / 100);
                    _savedAmmount = _originalPrice - _discountedPrice;
                }
                else
                {
                    _discountedPrice = _originalPrice;
                    _savedAmmount = 0;
                }
                return _discountedPrice;
            }
        }

        public double SavedAmount { get => _savedAmmount; }

        public bool HasAnyPromotionalOffer { get; set; } = false;

        public PromotionalOffer PromotionalOffer { get; set; } = PromotionalOffer.None;

        public Product Clone
        {
            get
            {
                var obj = (Product) this.MemberwiseClone();
                obj.Name = string.Copy(Name);
                obj.Category = string.Copy(Category);
                obj.HasAnyPromotionalOffer = false;
                obj.PromotionalOffer = PromotionalOffer.None;
                return obj;
            }
        }
    }
}
