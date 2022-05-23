using System;
using System.Collections.Generic;

#nullable disable

namespace WebSkladTest1.db
{
    public partial class Shop
    {
        public Shop()
        {
            OrderOuts = new HashSet<OrderOut>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public virtual ICollection<OrderOut> OrderOuts { get; set; }
    }
}
