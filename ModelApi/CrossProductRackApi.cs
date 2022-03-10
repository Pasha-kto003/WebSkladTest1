using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelApi
{
    public class CrossProductRackApi
    {
        public int RackId { get; set; }
        public int ProductId { get; set; }
        public DateTime? PlacementDate { get; set; }
        public DateTime? DeletionDate { get; set; }
        public int? RemainingPlaces { get; set; }
        public RackApi Rack { get; set; }
        public ProductApi Product { get; set; }
    }
}
