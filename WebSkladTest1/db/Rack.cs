using System;
using System.Collections.Generic;

#nullable disable

namespace WebSkladTest1.db
{
    public partial class Rack
    {
        public Rack()
        {
            CrossProductRacks = new HashSet<CrossProductRack>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Capacity { get; set; }
        public int? PersonalId { get; set; }
        public int? RemainingPlaces { get; set; }
        public DateTime? DeletionDate { get; set; }
        public DateTime? PlacementDate { get; set; }
        public DateTime ChangedDate { get; set; }

        public virtual Personal Personal { get; set; }
        public virtual ICollection<CrossProductRack> CrossProductRacks { get; set; }
    }
}
