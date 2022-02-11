using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelApi
{
    public class RackApi
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Capacity { get; set; }
        public int? PersonalId { get; set; }

        public List<ProductApi> Products { get; set; }
    }
}
