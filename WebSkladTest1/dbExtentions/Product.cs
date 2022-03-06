using ModelApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSkladTest1.db
{
    public partial class Product
    {
        public static explicit operator ProductApi(Product product)
        {
            return new ProductApi
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                CountInStock = product.CountInStock,
                BestBeforeDateStart = product.BestBeforeDateStart,
                BestBeforeDateEnd = product.BestBeforeDateEnd,
                Status = product.Status,
                UnitId = product.UnitId,
                ProductTypeId = product.ProductTypeId,
                CountProducts = product.CountProducts
            };
        }

        public static explicit operator Product(ProductApi product)
        {
            return new Product
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                CountInStock = product.CountInStock,
                BestBeforeDateStart = product.BestBeforeDateStart,
                BestBeforeDateEnd = product.BestBeforeDateEnd,
                Status = product.Status,
                UnitId = product.UnitId,
                ProductTypeId = product.ProductTypeId,
                CountProducts = product.CountProducts
            };
        }
    }
}
