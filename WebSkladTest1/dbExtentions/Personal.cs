using ModelApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSkladTest1.db
{
    public partial class Personal
    {
        public static explicit operator PersonalApi(Personal personal)
        {
            return new PersonalApi
            {
                Id = personal.Id,
                FirstName = personal.FirstName,
                LastName = personal.LastName,
                Patronimyc = personal.Patronimyc,
                Rating = personal.Rating,
                Phone = personal.Phone,
                Image = personal.Image,
                DateEndWork = personal.DateEndWork,
                DateStartWork = personal.DateStartWork,
                StatusId = personal.StatusId
            };
        }

        public static explicit operator Personal(PersonalApi personal)
        {
            return new Personal
            {
                Id = personal.Id,
                FirstName = personal.FirstName,
                LastName = personal.LastName,
                Patronimyc = personal.Patronimyc,
                Rating = personal.Rating,
                Phone = personal.Phone,
                Image = personal.Image,
                DateEndWork = personal.DateEndWork,
                DateStartWork = personal.DateStartWork,
                StatusId = personal.StatusId
            };
        }
    }
}
