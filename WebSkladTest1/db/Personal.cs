using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSkladTest1.db
{
    public partial class Personal
    {
        public Personal()
        {
            Racks = new HashSet<Rack>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronimyc { get; set; }
        public int Rating { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public DateTime? DateStartWork { get; set; }
        public DateTime? DateEndWork { get; set; }
        public int? StatusId { get; set; }

        public virtual Status Status { get; set; }
        public virtual ICollection<Rack> Racks { get; set; }
    }
}
