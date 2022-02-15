using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelApi
{
    public class PersonalApi : ApiBaseType
    {       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronimyc { get; set; }
        public string Rating { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public DateTime? DateStartWork { get; set; }
        public DateTime? DateEndWork { get; set; }
        public int? StatusId { get; set; }
    }
}
