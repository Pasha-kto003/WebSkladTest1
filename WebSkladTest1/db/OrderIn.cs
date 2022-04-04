using System;
using System.Collections.Generic;

#nullable disable

namespace WebSkladTest1.db
{
    public partial class OrderIn
    {
        public OrderIn()
        {
            CrossProductOrders = new HashSet<CrossProductOrder>();
        }

        public int Id { get; set; }
        public DateTime DateOrderIn { get; set; }
        public int? SupplierId { get; set; }
        public string Status { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<CrossProductOrder> CrossProductOrders { get; set; }
    }
}
