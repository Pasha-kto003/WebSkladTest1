using ModelApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSkladTest1.db
{
    public partial class CrossProductOrder
    {
        public static explicit operator CrossProductOrderApi(CrossProductOrder crossProduct)
        {
            return new CrossProductOrderApi
            {
                CountInOrder = crossProduct.CountInOrder,
                OrderInId = crossProduct.OrderInId,
                ProductId = crossProduct.ProductId
            };
        }

        public static explicit operator CrossProductOrder(CrossProductOrderApi crossProduct)
        {
            return new CrossProductOrder
            {
                CountInOrder = crossProduct.CountInOrder,
                OrderInId = crossProduct.OrderInId,
                ProductId = crossProduct.ProductId
            };
        }
    }
}
