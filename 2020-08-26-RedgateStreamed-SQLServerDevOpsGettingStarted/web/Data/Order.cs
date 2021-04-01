using System;
using System.Collections.Generic;

namespace ASiteToOrderStuff.Web
{
    public partial class Order
    {
        public Order()
        {
            OrderLineItems = new HashSet<OrderLineItem>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public DateTime DateTimeOrdered { get; set; }
        public DateTime? DateTimeSentOutForDelivery { get; set; }
        public string DateTimeDelivered { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderLineItem> OrderLineItems { get; set; }
    }
}
