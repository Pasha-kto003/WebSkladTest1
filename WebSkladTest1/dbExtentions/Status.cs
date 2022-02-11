using ModelApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSkladTest1.db
{
    public partial class Status
    {
        public static explicit operator StatusApi(Status status)
        {
            return new StatusApi
            {
                Id = status.Id,
                Title = status.Title
            };
        }

        public static explicit operator Status(StatusApi status)
        {
            return new Status
            {
                Id = status.Id,
                Title = status.Title
            };
        }
    }
}
