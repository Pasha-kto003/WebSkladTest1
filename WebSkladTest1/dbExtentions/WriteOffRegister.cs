using ModelApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSkladTest1.db
{
    public partial class WriteOffRegister
    {
        public static explicit operator WriteOffRegisterApi(WriteOffRegister register)
        {
            return new WriteOffRegisterApi
            {
                Id = register.Id,
                DeletedAt = register.DeltedAt,
                ReasonDelete = register.ReasonDelete,
                Title = register.Title,
                ProductId = register.ProductId
            };
        }

        public static explicit operator WriteOffRegister(WriteOffRegisterApi register)
        {
            return new WriteOffRegister
            {
                Id = register.Id,
                DeltedAt = register.DeletedAt,
                ReasonDelete = register.ReasonDelete,
                Title = register.Title,
                ProductId = register.ProductId
            };
        }
    }
}
