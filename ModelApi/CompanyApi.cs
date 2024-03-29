﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelApi
{
    public class CompanyApi : ApiBaseType
    {
        public string NameOfCompany { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
