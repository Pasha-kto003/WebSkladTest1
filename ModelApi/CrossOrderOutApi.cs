using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelApi
{
    public class CrossOrderOutApi
    {
        public int ProductId { get; set; }
        public int OrderOutId { get; set; }
        public int? CountOutOrder { get; set; }
    }
}
