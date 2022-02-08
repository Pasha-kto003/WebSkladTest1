using ModelApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSkladTest1.db
{
    public partial class OrderIn
    {
        public static explicit operator OrderInApi(OrderIn orderIn)
        {
            return new OrderInApi
            {
                Id = orderIn.Id,
                DateOrderIn = orderIn.DateOrderIn,
                SupplierId = orderIn.SupplierId,
                Status = orderIn.Status
                
            };
        }
        public static explicit operator OrderIn(OrderInApi orderIn)
        {
            return new OrderIn
            {
                Id = orderIn.Id,
                DateOrderIn = orderIn.DateOrderIn,
                SupplierId = orderIn.SupplierId,
                Status = orderIn.Status
            };
        }
    }
}
