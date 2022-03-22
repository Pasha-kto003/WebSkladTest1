using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelApi
{
    public class ProductApi : ApiBaseType
    {      
        public string Title { get; set; }
        public string Description { get; set; }
        public int CountInStock { get; set; }
        public DateTime? BestBeforeDateStart { get; set; }
        public DateTime? BestBeforeDateEnd { get; set; }
        public int? UnitId { get; set; }
        public int? ProductTypeId { get; set; }
        public string Status { get; set; }

        public UnitApi Unit { get; set; }
        public ProductTypeApi ProductType { get; set; }
        public CrossProductOrderApi CrossProductOrderApi { get; set; }
        public CrossOrderOutApi CrossOrderOutApi { get; set; }
        public CrossProductRackApi CrossProductRack { get; set; }

        public int? CountProducts { get; set; }
        public int? CountProductsOut { get; set; }
    }
}
