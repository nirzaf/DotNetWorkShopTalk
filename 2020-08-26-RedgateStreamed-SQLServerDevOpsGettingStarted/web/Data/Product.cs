using System.Collections.Generic;

namespace ASiteToOrderStuff.Web
{
    public partial class Product
    {
        public Product()
        {
            OrderLineItems = new HashSet<OrderLineItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }

        public virtual ICollection<OrderLineItem> OrderLineItems { get; set; }
    }
}
