using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelApi
{
    public class SupplierApi : ApiBaseType
    {       
        public string Title { get; set; }
        public int? Rating { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public List<ProductApi> Products { get; set; }
        public ProductSupplierApi ProductSupplier { get; set; }
    }
}
