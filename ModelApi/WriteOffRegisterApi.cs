using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelApi
{
    public class WriteOffRegisterApi : ApiBaseType
    {
        public string Title { get; set; }
        public string ReasonDelete { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? ProductId { get; set; }
        public ProductApi Product { get; set; }
    }
}
