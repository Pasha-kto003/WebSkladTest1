using System;
using System.Collections.Generic;

#nullable disable

namespace WebSkladTest1.db
{
    public partial class Product
    {
        public Product()
        {
            CrossOrderOuts = new HashSet<CrossOrderOut>();
            CrossProductOrders = new HashSet<CrossProductOrder>();
            CrossProductRacks = new HashSet<CrossProductRack>();
            WriteOffRegisters = new HashSet<WriteOffRegister>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CountInStock { get; set; }
        public DateTime? BestBeforeDateStart { get; set; }
        public DateTime? BestBeforeDateEnd { get; set; }
        public int? ProductTypeId { get; set; }
        public int? UnitId { get; set; }
        public string Status { get; set; }

        public virtual ProductType ProductType { get; set; }
        public virtual Unit Unit { get; set; }
        public virtual ICollection<CrossOrderOut> CrossOrderOuts { get; set; }
        public virtual ICollection<CrossProductOrder> CrossProductOrders { get; set; }
        public virtual ICollection<CrossProductRack> CrossProductRacks { get; set; }
        public virtual ICollection<WriteOffRegister> WriteOffRegisters { get; set; }
    }
}
