﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace panasonic.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241022104300_AddUserAndRoleTableWithSeeder")]
    partial class AddUserAndRoleTableWithSeeder
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("panasonic.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayName = "Guest",
                            RoleName = "Guest"
                        },
                        new
                        {
                            Id = 2,
                            DisplayName = "Admin",
                            RoleName = "Admin"
                        },
                        new
                        {
                            Id = 3,
                            DisplayName = "Store Manager",
                            RoleName = "StoreManager"
                        },
                        new
                        {
                            Id = 4,
                            DisplayName = "Shift Leader",
                            RoleName = "ShiftLeader"
                        },
                        new
                        {
                            Id = 5,
                            DisplayName = "Asistant Leader",
                            RoleName = "AsistantLeader"
                        });
                });

            modelBuilder.Entity("panasonic.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("EmployeeID")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@email.com",
                            EmployeeID = 301010,
                            Fullname = "Admin",
                            HashedPassword = "AQAAAAIAAYagAAAAEJ3FC2c74C+Xhqx/qlBpZFSFDRdZTjoSzgQxeOLaxp7XFsBO+T8LpvHOOIxkygh/mA==",
                            IsVerified = true,
                            RoleId = 2
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "asistantleader@email.com",
                            EmployeeID = 301011,
                            Fullname = "Asistant Leader",
                            HashedPassword = "AQAAAAIAAYagAAAAEPXcmBoEfcJkny1YX+9IaQsLJohC5dqOImo84zoLdZBrMZfw7s6X8GbGrRWnsQ/WYA==",
                            IsVerified = true,
                            RoleId = 5
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "shiftleader@email.com",
                            EmployeeID = 301012,
                            Fullname = "Shift Leader",
                            HashedPassword = "AQAAAAIAAYagAAAAEBCVxgxxdSRwO47D6lx4XalJgDkgbGihLdEgjRNdBdQ9pcMv72sw9/6F6amvoQImDA==",
                            IsVerified = true,
                            RoleId = 4
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "storemanager@email.com",
                            EmployeeID = 301013,
                            Fullname = "Store Manager",
                            HashedPassword = "AQAAAAIAAYagAAAAELVIGutIdZqPsVdt5/IVOe+vWo8l+FRkX0gQ4vwxW9W2LkpWAgcksFgDfZTLLlq2hg==",
                            IsVerified = true,
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("panasonic.Models.User", b =>
                {
                    b.HasOne("panasonic.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
