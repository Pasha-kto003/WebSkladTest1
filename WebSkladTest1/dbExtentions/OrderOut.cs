using ModelApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSkladTest1.db
{
    public partial class OrderOut
    {
        public static explicit operator OrderOutApi(OrderOut orderOut)
        {
            return new OrderOutApi
            {
                Id = orderOut.Id,
                DateOrderOut = orderOut.DateOrderOut,
                ShopId = orderOut.ShopId,
                Status = orderOut.Status,
                SupplierId = orderOut.SupplierId
            };
        }

        public static explicit operator OrderOut(OrderOutApi orderOut)
        {
            return new OrderOut
            {
                Id = orderOut.Id,
                DateOrderOut = orderOut.DateOrderOut,
                ShopId = orderOut.ShopId,
                Status = orderOut.Status,
                SupplierId = orderOut.SupplierId
            };
        }
    }
}
