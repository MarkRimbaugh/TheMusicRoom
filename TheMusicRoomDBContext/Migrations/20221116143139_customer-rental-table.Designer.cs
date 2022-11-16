﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheMusicRoomDB;

#nullable disable

namespace TheMusicRoomDB.Migrations
{
    [DbContext(typeof(TheMusicRoomDBContext))]
    [Migration("20221116143139_customer-rental-table")]
    partial class customerrentaltable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CustomerRental", b =>
                {
                    b.Property<int>("CustomersId")
                        .HasColumnType("int");

                    b.Property<int>("RentalsId")
                        .HasColumnType("int");

                    b.HasKey("CustomersId", "RentalsId");

                    b.HasIndex("RentalsId");

                    b.ToTable("CustomerRental");
                });

            modelBuilder.Entity("TheMusicRoomDBModels.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Fender"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Gibson"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Line 6"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Taylor"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Yamaha"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Korg"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Casio"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Tama"
                        });
                });

            modelBuilder.Entity("TheMusicRoomDBModels.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("First")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Last")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Middle")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("PhoneId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("PhoneId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressId = 1,
                            First = "Mark",
                            Last = "Rimbaugh",
                            Middle = "",
                            PhoneId = 1
                        },
                        new
                        {
                            Id = 2,
                            AddressId = 2,
                            First = "Joshua",
                            Last = "Benson",
                            Middle = "",
                            PhoneId = 2
                        },
                        new
                        {
                            Id = 3,
                            AddressId = 3,
                            First = "Drew",
                            Last = "Nelson",
                            Middle = "",
                            PhoneId = 3
                        },
                        new
                        {
                            Id = 4,
                            AddressId = 4,
                            First = "Rico",
                            Last = "Rodriguez",
                            Middle = "",
                            PhoneId = 4
                        },
                        new
                        {
                            Id = 5,
                            AddressId = 5,
                            First = "Jackson",
                            Last = "Freiburg",
                            Middle = "",
                            PhoneId = 5
                        });
                });

            modelBuilder.Entity("TheMusicRoomDBModels.CustomerAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CustomerAddresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Hope Mills",
                            State = "North Carolina",
                            Street = "892 Some Road",
                            Zip = "12345-0000"
                        },
                        new
                        {
                            Id = 2,
                            City = "Fayetteville",
                            State = "North Carolina",
                            Street = "429 That Avenue",
                            Zip = "67891-0000"
                        },
                        new
                        {
                            Id = 3,
                            City = "South Bend",
                            State = "Indiana",
                            Street = "403 S. 29th Street",
                            Zip = "89172-0000"
                        },
                        new
                        {
                            Id = 4,
                            City = "Anchorage",
                            State = "Alaska",
                            Street = "123 Fake Street",
                            Zip = "68981-0000"
                        },
                        new
                        {
                            Id = 5,
                            City = "Leesville",
                            State = "Louisiana",
                            Street = "456 Another Street",
                            Zip = "01597-0000"
                        });
                });

            modelBuilder.Entity("TheMusicRoomDBModels.CustomerPhone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CustomerPhones");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Number = "123-456-7890",
                            Type = 2
                        },
                        new
                        {
                            Id = 2,
                            Number = "234-567-8901",
                            Type = 1
                        },
                        new
                        {
                            Id = 3,
                            Number = "345-678-9012",
                            Type = 0
                        },
                        new
                        {
                            Id = 4,
                            Number = "456-789-0123",
                            Type = 2
                        },
                        new
                        {
                            Id = 5,
                            Number = "567-890-1234",
                            Type = 2
                        });
                });

            modelBuilder.Entity("TheMusicRoomDBModels.DTOs.EquipmentListDTO", b =>
                {
                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Condition")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.ToTable((string)null);

                    b.ToView("CourseInfoDTOs", (string)null);
                });

            modelBuilder.Entity("TheMusicRoomDBModels.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeAddressId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeePhoneId")
                        .HasColumnType("int");

                    b.Property<string>("First")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Last")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Middle")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeAddressId");

                    b.HasIndex("EmployeePhoneId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmployeeAddressId = 1,
                            EmployeePhoneId = 1,
                            First = "Brian",
                            Last = "Gorman",
                            Middle = "",
                            Position = 0
                        },
                        new
                        {
                            Id = 2,
                            EmployeeAddressId = 2,
                            EmployeePhoneId = 2,
                            First = "Patrick",
                            Last = "Larson",
                            Middle = "",
                            Position = 1
                        },
                        new
                        {
                            Id = 3,
                            EmployeeAddressId = 3,
                            EmployeePhoneId = 3,
                            First = "Ahmad",
                            Last = "Qaderyan",
                            Middle = "Rohin",
                            Position = 1
                        },
                        new
                        {
                            Id = 4,
                            EmployeeAddressId = 4,
                            EmployeePhoneId = 4,
                            First = "Mursal",
                            Last = "Qaderyan",
                            Middle = "",
                            Position = 1
                        },
                        new
                        {
                            Id = 5,
                            EmployeeAddressId = 5,
                            EmployeePhoneId = 5,
                            First = "Alex",
                            Last = "Robinson",
                            Middle = "",
                            Position = 1
                        });
                });

            modelBuilder.Entity("TheMusicRoomDBModels.EmployeeAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EmployeeAddresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Fayetteville",
                            State = "North Carolina",
                            Street = "123 Sample Street",
                            Zip = "46514-0000"
                        },
                        new
                        {
                            Id = 2,
                            City = "Fayetteville",
                            State = "North Carolina",
                            Street = "249 MadeUp Road",
                            Zip = "46514-0000"
                        },
                        new
                        {
                            Id = 3,
                            City = "Raeford",
                            State = "North Carolina",
                            Street = "903 Imaginary Circle",
                            Zip = "46514-0000"
                        },
                        new
                        {
                            Id = 4,
                            City = "Sanford",
                            State = "North Carolina",
                            Street = "191 Nonexistent Lane",
                            Zip = "46514-0000"
                        },
                        new
                        {
                            Id = 5,
                            City = "Southern Pines",
                            State = "North Carolina",
                            Street = "902 Fake Street",
                            Zip = "46514-0000"
                        });
                });

            modelBuilder.Entity("TheMusicRoomDBModels.EmployeePhone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("EmployeePhones");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Number = "123-456-7890",
                            Type = 1
                        },
                        new
                        {
                            Id = 2,
                            Number = "234-567-8901",
                            Type = 1
                        },
                        new
                        {
                            Id = 3,
                            Number = "345-678-9012",
                            Type = 1
                        },
                        new
                        {
                            Id = 4,
                            Number = "456-789-0123",
                            Type = 1
                        },
                        new
                        {
                            Id = 5,
                            Number = "567-890-1234",
                            Type = 1
                        });
                });

            modelBuilder.Entity("TheMusicRoomDBModels.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Condition")
                        .HasColumnType("int");

                    b.Property<int>("EquipmentTypeId")
                        .HasColumnType("int");

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentTypeId");

                    b.HasIndex("ModelId");

                    b.ToTable("Equipment");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Condition = 0,
                            EquipmentTypeId = 1,
                            ModelId = 1
                        },
                        new
                        {
                            Id = 2,
                            Condition = 1,
                            EquipmentTypeId = 1,
                            ModelId = 1
                        },
                        new
                        {
                            Id = 3,
                            Condition = 1,
                            EquipmentTypeId = 2,
                            ModelId = 7
                        },
                        new
                        {
                            Id = 4,
                            Condition = 2,
                            EquipmentTypeId = 3,
                            ModelId = 8
                        },
                        new
                        {
                            Id = 5,
                            Condition = 4,
                            EquipmentTypeId = 2,
                            ModelId = 10
                        });
                });

            modelBuilder.Entity("TheMusicRoomDBModels.EquipmentRental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RentalDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("EquipmentId");

                    b.ToTable("EquipmentRental");
                });

            modelBuilder.Entity("TheMusicRoomDBModels.EquipmentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("EquipmentTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Guitar"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Keyboard"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Drums"
                        });
                });

            modelBuilder.Entity("TheMusicRoomDBModels.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Models");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            Name = "Stratocaster"
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 1,
                            Name = "Telecaster"
                        },
                        new
                        {
                            Id = 3,
                            BrandId = 1,
                            Name = "Acoustasonic"
                        },
                        new
                        {
                            Id = 4,
                            BrandId = 2,
                            Name = "Les Paul"
                        },
                        new
                        {
                            Id = 5,
                            BrandId = 2,
                            Name = "SG"
                        },
                        new
                        {
                            Id = 6,
                            BrandId = 3,
                            Name = "JTV-89F"
                        },
                        new
                        {
                            Id = 7,
                            BrandId = 4,
                            Name = "214ce"
                        },
                        new
                        {
                            Id = 8,
                            BrandId = 5,
                            Name = "DGX670B"
                        },
                        new
                        {
                            Id = 9,
                            BrandId = 6,
                            Name = "i3 Arranger"
                        },
                        new
                        {
                            Id = 10,
                            BrandId = 7,
                            Name = "WK-7600"
                        },
                        new
                        {
                            Id = 11,
                            BrandId = 8,
                            Name = "Superstar Classic"
                        });
                });

            modelBuilder.Entity("TheMusicRoomDBModels.Rental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RentDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Rental");
                });

            modelBuilder.Entity("CustomerRental", b =>
                {
                    b.HasOne("TheMusicRoomDBModels.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheMusicRoomDBModels.Rental", null)
                        .WithMany()
                        .HasForeignKey("RentalsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TheMusicRoomDBModels.Customer", b =>
                {
                    b.HasOne("TheMusicRoomDBModels.CustomerAddress", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheMusicRoomDBModels.CustomerPhone", "Phone")
                        .WithMany()
                        .HasForeignKey("PhoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Phone");
                });

            modelBuilder.Entity("TheMusicRoomDBModels.Employee", b =>
                {
                    b.HasOne("TheMusicRoomDBModels.EmployeeAddress", "Address")
                        .WithMany()
                        .HasForeignKey("EmployeeAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheMusicRoomDBModels.EmployeePhone", "Phone")
                        .WithMany()
                        .HasForeignKey("EmployeePhoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Phone");
                });

            modelBuilder.Entity("TheMusicRoomDBModels.Equipment", b =>
                {
                    b.HasOne("TheMusicRoomDBModels.EquipmentType", "Type")
                        .WithMany()
                        .HasForeignKey("EquipmentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheMusicRoomDBModels.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("TheMusicRoomDBModels.EquipmentRental", b =>
                {
                    b.HasOne("TheMusicRoomDBModels.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheMusicRoomDBModels.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheMusicRoomDBModels.Equipment", "Equipment")
                        .WithMany("EquipmentRentals")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Employee");

                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("TheMusicRoomDBModels.Equipment", b =>
                {
                    b.Navigation("EquipmentRentals");
                });
#pragma warning restore 612, 618
        }
    }
}