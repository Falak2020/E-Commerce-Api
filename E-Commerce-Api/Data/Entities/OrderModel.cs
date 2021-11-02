using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Api.Data.Entities
{
    public class OrderModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        [Column(TypeName ="nvarchar(50)")]
        public string OurReference { get; set; }

        [Required]
        public string Status { get; set; }
        [Required]
        public int DeliveryTypeId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int DeliveryAddressId { get; set; }

        public virtual DeliveryTypeModel DeliveryType { get; set; }
        public virtual UserModel User { get; set; }

        public virtual ICollection<OrderItemModel>   OrderItems { get; set; }


    }
}
