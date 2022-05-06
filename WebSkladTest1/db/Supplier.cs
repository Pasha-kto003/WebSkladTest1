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
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public int? Rating { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? CompanyId { get; set; }
        public string LastName { get; set; }
        public string Patronimyc { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<OrderIn> OrderIns { get; set; }
        public virtual ICollection<OrderOut> OrderOuts { get; set; }
    }
}
