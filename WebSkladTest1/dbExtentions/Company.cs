using ModelApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSkladTest1.db
{
    public partial class Company
    {
        public static explicit operator CompanyApi(Company company)
        {
            return new CompanyApi
            {
                Id = company.Id,
                Email = company.Email,
                Image = company.Image,
                Phone = company.Phone,
                NameOfCompany = company.NameOfCompany,
                RegistrationDate = company.RegistrationDate
            };
        }

        public static explicit operator Company(CompanyApi company)
        {
            return new Company
            {
                Id = company.Id,
                Email = company.Email,
                Image = company.Image,
                Phone = company.Phone,
                NameOfCompany = company.NameOfCompany,
                RegistrationDate = company.RegistrationDate
            };
        }
    }
}
