using System;
using System.Collections.Generic;

#nullable disable

namespace WebSkladTest1.db
{
    public partial class Company
    {
        public Company()
        {
            Suppliers = new HashSet<Supplier>();
        }

        public int Id { get; set; }
        public string NameOfCompany { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
