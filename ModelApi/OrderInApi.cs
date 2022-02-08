using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelApi
{
    public class OrderInApi
    {
        public int Id { get; set; }
        public DateTime? DateOrderIn { get; set; }
        public string Status { get; set; }
        public int? SupplierId { get; set; }

        public List<ProductApi> Products { get; set; }
    }
}
