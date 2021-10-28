using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Api.Data.Entities
{
    public class PasswordHashModel
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "varchar(max)")]
        public string Password { get; set; }

        public virtual UserModel User { get; set; }
    }
}
