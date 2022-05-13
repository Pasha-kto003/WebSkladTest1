using System;
using System.Collections.Generic;

#nullable disable

namespace WebSkladTest1.db
{
    public partial class User
    {
        public User()
        {
            OrderIns = new HashSet<OrderIn>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<OrderIn> OrderIns { get; set; }
    }
}
