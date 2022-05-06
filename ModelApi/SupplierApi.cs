using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelApi
{
    public class SupplierApi : ApiBaseType
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronimyc { get; set; }
        public int? Rating { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? CompanyId { get; set; }

        public CompanyApi Company { get; set; }
    }
}
