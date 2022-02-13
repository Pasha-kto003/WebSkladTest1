using ModelApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSkladTest1.db
{
    public partial class CrossProductRack
    {
        public static explicit operator CrossProductRackApi(CrossProductRack crossProduct)
        {
            return new CrossProductRackApi
            {
                DeletionDate = crossProduct.DeletionDate,
                PlacementDate = crossProduct.PlacementDate,
                RemainingPlaces = crossProduct.RemainingPlaces,
                ProductId = crossProduct.ProductId,
                RackId = crossProduct.RackId
            };
        }

        public static explicit operator CrossProductRack(CrossProductRackApi crossProduct)
        {
            return new CrossProductRack
            {
                DeletionDate = crossProduct.DeletionDate,
                PlacementDate = crossProduct.PlacementDate,
                RemainingPlaces = crossProduct.RemainingPlaces,
                ProductId = crossProduct.ProductId,
                RackId = crossProduct.RackId
            };
        }
    }
}
