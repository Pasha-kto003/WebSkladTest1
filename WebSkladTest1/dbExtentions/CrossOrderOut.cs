using ModelApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSkladTest1.db
{
    public partial class CrossOrderOut
    {
        public static explicit operator CrossOrderOutApi(CrossOrderOut crossProduct)
        {
            return new CrossOrderOutApi
            {
                CountOutOrder = crossProduct.CountOutOrder,
                OrderOutId = crossProduct.OrderOutId,
                ProductId = crossProduct.ProductId
            };
        }

        public static explicit operator CrossOrderOut(CrossOrderOutApi crossProduct)
        {
            return new CrossOrderOut
            {
                CountOutOrder = crossProduct.CountOutOrder,
                OrderOutId = crossProduct.OrderOutId,
                ProductId = crossProduct.ProductId
            };
        }
    }
}
