using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSkladTest1.db
{
    public partial class Status
    {
        public Status()
        {
            Personals = new HashSet<Personal>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Personal> Personals { get; set; }
    }
}
