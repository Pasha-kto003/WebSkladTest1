using System;
using System.Collections.Generic;

#nullable disable

namespace WebSkladTest1.db
{
    public partial class CrossOrderOut
    {
        public int ProductId { get; set; }
        public int OrderOutId { get; set; }
        public int? CountOutOrder { get; set; }

        public virtual OrderOut OrderOut { get; set; }
        public virtual Product Product { get; set; }
    }
}
