using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelApi
{
    public class CrossProductOrderApi
    {
        public int ProductId { get; set; }
        public int OrderInId { get; set; }
        public int? CountInOrder { get; set; }

        //public ProductApi Product { get; set; }
    }
}
