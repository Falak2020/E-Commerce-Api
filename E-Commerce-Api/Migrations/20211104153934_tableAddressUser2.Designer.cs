// <auto-generated />
using System;
using E_Commerce_Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace E_Commerce_Api.Migrations
{
    [DbContext(typeof(SqlContext))]
    [Migration("20211104153934_tableAddressUser2")]
    partial class tableAddressUser2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("E_Commerce_Api.Data.Entities.AddressModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("UserAddressId")
                        .HasColumnType("int");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("UserAddressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("E_Commerce_Api.Data.Entities.CategoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("E_Commerce_Api.Data.Entities.DeliveryTypeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("DeliveryTypeModel");
                });

            modelBuilder.Entity("E_Commerce_Api.Data.Entities.OrderItemModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItemModel");
                });

            modelBuilder.Entity("E_Commerce_Api.Data.Entities.OrderModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressModelId")
                        .HasColumnType("int");

                    b.Property<int>("DeliveryAddressId")
                        .HasColumnType("int");

                    b.Property<int>("DeliveryTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OurReference")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserAddressId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressModelId");

                    b.HasIndex("DeliveryTypeId");

                    b.HasIndex("UserAddressId");

                    b.HasIndex("UserId");

                    b.ToTable("OrderModel");
                });

            modelBuilder.Entity("E_Commerce_Api.Data.Entities.PasswordHashModel", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("PasswordHashes");
                });

            modelBuilder.Entity("E_Commerce_Api.Data.Entities.ProductModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(8192)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("InStock")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<int>("SubCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("E_Commerce_Api.Data.Entities.SubCategoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("E_Commerce_Api.Data.Entities.UserAddressModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("userAddresses");
                });

            modelBuilder.Entity("E_Commerce_Api.Data.Entities.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("UserAddressId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserAddressId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("E_Commerce_Api.Data.Entities.AddressModel", b =>
                {
                    b.HasOne("E_Commerce_Api.Data.Entities.UserAddressModel", "UserAddress")
                        .WithMany("Addresses")
                        .HasForeignKey("UserAddressId");

                    b.Navigation("UserAddress");
                });

            modelBuilder.Entity("E_Commerce_Api.Data.Entities.OrderItemModel", b =>
                {
                    b.HasOne("E_Commerce_Api.Data.Entities.OrderModel", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Commerce_Api.Data.Entities.ProductModel", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("E_Commerce_Api.Data.Entities.OrderModel", b =>
                {
                    b.HasOne("E_Commerce_Api.Data.Entities.AddressModel", null)
                        .WithMany("Orders")
                        .HasForeignKey("AddressModelId");

                    b.HasOne("E_Commerce_Api.Data.Entities.DeliveryTypeModel", "DeliveryType")
                        .WithMany("Orders")
                        .HasForeignKey("DeliveryTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Commerce_Api.Data.Entities.UserAddressModel", "UserAddress")
                        .WithMany("Orders")
                        .HasForeignKey("UserAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Commerce_Api.Data.Entities.UserModel", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeliveryType");

                    b.Navigation("User");

                    b.Navigation("UserAddress");
                });

            modelBuilder.Entity("E_Commerce_Api.Data.Entities.PasswordHashModel", b =>
                {
                    b.HasOne("E_Commerce_Api.Data.Entities.UserModel", "User")
                        .WithOne("PasswordHash")
                        .HasForeignKey("E_Commerce_Api.Data.Entities.PasswordHashModel", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("E_Commerce_Api.Data.Entities.ProductModel", b =>
                {
                    b.HasOne("E_Commerce_Api.Data.Entities.SubCategoryModel", "SubCategory")
                        .WithMany("Products")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("E_Commerce_Api.Data.Entities.SubCategoryModel", b =>
                {
                    b.HasOne("E_Commerce_Api.Data.Entities.CategoryModel", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("E_Commerce_Api.Data.Entities.UserModel", b =>
                {
                    b.HasOne("E_Commerce_Api.Data.Entities.UserAddressModel", "UserAddress")
                        .WithMany("Users")
                        .HasForeignKey("UserAddressId");

                    b.Navigation("UserAddress");
                });

            modelBuilder.Entity("E_Commerce_Api.Data.Entities.AddressModel", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("E_Commerce_Api.Data.Entities.CategoryModel", b =>
                {
                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("E_Commerce_Api.Data.Entities.DeliveryTypeModel", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("E_Commerce_Api.Data.Entities.OrderModel", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("E_Commerce_Api.Data.Entities.ProductModel", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("E_Commerce_Api.Data.Entities.SubCategoryModel", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("E_Commerce_Api.Data.Entities.UserAddressModel", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Orders");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("E_Commerce_Api.Data.Entities.UserModel", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("PasswordHash")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
