using ModelApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSkladTest1.db
{
    public partial class Shop
    {
        public static explicit operator ShopApi(Shop shop)
        {
            return new ShopApi
            {
                Id = shop.Id,
                Email = shop.Email,
                Name = shop.Name,
                Phone = shop.Phone
            };
        }

        public static explicit operator Shop(ShopApi shop)
        {
            return new Shop
            {
                Id = shop.Id,
                Email = shop.Email,
                Name = shop.Name,
                Phone = shop.Phone
            };
        }
    }
}
