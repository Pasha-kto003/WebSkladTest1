using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelApi
{
    public class RackApi : ApiBaseType
    {        
        public string Name { get; set; }
        public int? Capacity { get; set; }
        public int? PersonalId { get; set; }
        public int? RemainingPlaces { get; set; }
        public DateTime? PlacementDate { get; set; }
        public DateTime? DeletionDate { get; set; }
        public DateTime ChangedDate { get; set; }
        

        public PersonalApi Personal { get; set; }
        public List<ProductApi> Products { get; set; }
        public List<CrossProductRackApi> CrossProductRacks { get; set; }
    }
}
