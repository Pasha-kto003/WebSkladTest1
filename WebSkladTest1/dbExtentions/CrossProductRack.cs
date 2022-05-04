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
                ProductId = crossProduct.ProductId,
                RackId = crossProduct.RackId,
                DateProductPlacement = crossProduct.DateProductPlacement
            };
        }

        public static explicit operator CrossProductRack(CrossProductRackApi crossProduct)
        {
            return new CrossProductRack
            {
                ProductId = crossProduct.ProductId,
                RackId = crossProduct.RackId,
                DateProductPlacement = crossProduct.DateProductPlacement
            };
        }
    }
}
