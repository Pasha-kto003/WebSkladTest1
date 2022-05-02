using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelApi
{
    public class OrderInApi : ApiBaseType
    {      
        public DateTime DateOrderIn { get; set; }
        public string Status { get; set; }
        public int? SupplierId { get; set; }

        public IEnumerable<CrossProductOrderApi> CrossProductOrders { get; set; }
        public SupplierApi Supplier { get; set; }
        public List<ProductApi> Products { get; set; }
    }
}
