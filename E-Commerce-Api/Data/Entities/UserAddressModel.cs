using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Api.Data.Entities
{
    public class UserAddressModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public virtual UserModel  User { get; set; }
        public virtual AddressModel Address { get; set; }
        public virtual ICollection<OrderModel> Orders { get; set; }



    }
}
