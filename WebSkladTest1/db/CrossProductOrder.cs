using System;
using System.Collections.Generic;

#nullable disable

namespace WebSkladTest1.db
{
    public partial class CrossProductOrder
    {
        public int ProductId { get; set; }
        public int OrderInId { get; set; }
        public int? CountInOrder { get; set; }

        public virtual OrderIn OrderIn { get; set; }
        public virtual Product Product { get; set; }
    }
}
