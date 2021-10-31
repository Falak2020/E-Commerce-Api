
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Api.Models.UserModel
{
    public class GetUserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AddressLine { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }

    }
}
