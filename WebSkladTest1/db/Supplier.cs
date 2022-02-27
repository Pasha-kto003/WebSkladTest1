using System;
using System.Collections.Generic;

#nullable disable

namespace WebSkladTest1.db
{
    public partial class Supplier
    {
        public Supplier()
        {
            OrderIns = new HashSet<OrderIn>();
            OrderOuts = new HashSet<OrderOut>();
            ProductSuppliers = new HashSet<ProductSupplier>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int? Rating { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<OrderIn> OrderIns { get; set; }
        public virtual ICollection<OrderOut> OrderOuts { get; set; }
        public virtual ICollection<ProductSupplier> ProductSuppliers { get; set; }
    }
}
