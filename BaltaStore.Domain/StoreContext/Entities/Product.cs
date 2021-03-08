using System;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Product
    {
        public Product(
            string title,
            string description,
            string image,
            decimal price,
            decimal quantity)
        {
            title = Title;
            description = Description;
            image = Image;
            price = Price;
            quantity = QuantityOnHand;
        }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Image { get; private set; }
        public decimal Price { get; private set; }
        public decimal QuantityOnHand { get; private set; }

        public override string ToString()
        {
            return Title;
        }
    }
}