﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelApi
{
    public class OrderOutApi
    {
        public int Id { get; set; }
        public DateTime? DateOrderOut { get; set; }
        public string Status { get; set; }
        public int? ShopId { get; set; }
        public int? SupplierId { get; set; }
        public List<ProductApi> Products { get; set; }
    }
}