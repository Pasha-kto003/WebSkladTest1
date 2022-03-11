using ModelApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSkladTest1.db
{
    public partial class Rack
    {
        public static explicit operator RackApi(Rack rack)
        {
            return new RackApi
            {
                Id = rack.Id,
                Capacity = rack.Capacity,
                Name = rack.Name,
                PersonalId = rack.PersonalId,
                RemainingPlaces = rack.RemainingPlaces,
                PlacementDate = rack.PlacementDate,
                DeletionDate = rack.DeletionDate,
                ChangedDate = rack.ChangedDate
            };
        }

        public static explicit operator Rack(RackApi rack)
        {
            return new Rack
            {
                Id = rack.Id,
                Capacity = rack.Capacity,
                Name = rack.Name,
                PersonalId = rack.PersonalId,
                RemainingPlaces = rack.RemainingPlaces,
                PlacementDate = rack.PlacementDate,
                DeletionDate = rack.DeletionDate,
                ChangedDate = rack.ChangedDate
            };
        }
    }
}
