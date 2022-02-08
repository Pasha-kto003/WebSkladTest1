using System;
using System.Collections.Generic;

#nullable disable

namespace WebSkladTest1.db
{
    public partial class WriteOffRegister
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? ProductId { get; set; }
        public string ReasonDelete { get; set; }
        public DateTime? DeltedAt { get; set; }

        public virtual Product Product { get; set; }
    }
}
