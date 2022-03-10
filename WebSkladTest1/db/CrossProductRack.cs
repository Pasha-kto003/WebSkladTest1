using System;
using System.Collections.Generic;

#nullable disable

namespace WebSkladTest1.db
{
    public partial class CrossProductRack
    {
        public int RackId { get; set; }
        public int ProductId { get; set; }
        public DateTime? PlacementDate { get; set; }
        public DateTime? DeletionDate { get; set; }

        public virtual Product Product { get; set; }
        public virtual Rack ProductNavigation { get; set; }
    }
}
