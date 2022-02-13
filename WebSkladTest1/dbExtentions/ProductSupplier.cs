using ModelApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSkladTest1.db
{
    public partial class ProductSupplier
    {
        public static explicit operator ProductSupplierApi(ProductSupplier productSupplier)
        {
            return new ProductSupplierApi
            {
                ProductId = productSupplier.ProductId,
                SupplierId = productSupplier.SupplierId
            };
        }

        public static explicit operator ProductSupplier(ProductSupplierApi productSupplier)
        {
            return new ProductSupplier
            {
                ProductId = productSupplier.ProductId,
                SupplierId = productSupplier.SupplierId
            };
        }
    }
}
