using System;
using System.Collections.Generic;

#nullable disable

namespace WebSkladTest1.db
{
    public partial class OrderOut
    {
        public OrderOut()
        {
            CrossOrderOuts = new HashSet<CrossOrderOut>();
        }

        public int Id { get; set; }
        public DateTime? DateOrderOut { get; set; }
        public string Status { get; set; }
        public int? ShopId { get; set; }

        public virtual Shop Shop { get; set; }
        public virtual ICollection<CrossOrderOut> CrossOrderOuts { get; set; }
    }
}
