using ModelApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSkladTest1.db
{
    public partial class Supplier
    {
        public static explicit operator SupplierApi(Supplier supplier)
        {
            return new SupplierApi
            {
                Id = supplier.Id,
                Email = supplier.Email,
                Title = supplier.Title,
                Phone = supplier.Phone,
                Rating = supplier.Rating
            };
        }
        public static explicit operator Supplier(SupplierApi supplier)
        {
            return new Supplier
            {
                Id = supplier.Id,
                Email = supplier.Email,
                Title = supplier.Title,
                Phone = supplier.Phone,
                Rating = supplier.Rating
            };
        }
    }
}
