
using E_Commerce_Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Api.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }
        public virtual DbSet<CategoryModel> Categories { get; set; }
        public virtual DbSet<SubCategoryModel> SubCategories { get; set; }
        public virtual DbSet<ProductModel> Products { get; set; }
        public virtual DbSet<PasswordHashModel> PasswordHashes { get; set; }
        public virtual DbSet<AddressModel> Addresses { get; set; }
        public virtual DbSet<UserModel> Users{ get; set; }
        public virtual DbSet<OrderModel> Orders { get; set; }
        public virtual DbSet<DeliveryTypeModel> DeliveryTypeModels { get; set; }








    }
}
