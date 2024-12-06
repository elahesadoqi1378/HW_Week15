﻿// <auto-generated />
using System;
using HW_Week15.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HW_Week15.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HW_Week15.Entities.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("Balance")
                        .HasColumnType("real");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("FailedLoginAttempts")
                        .HasColumnType("int");

                    b.Property<string>("HolderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Cards");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Balance = 1000f,
                            CardNumber = "6219861917648627",
                            FailedLoginAttempts = 0,
                            HolderName = "Elahe",
                            IsActive = true,
                            Password = "1234",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Balance = 2000f,
                            CardNumber = "6274121181669466",
                            FailedLoginAttempts = 0,
                            HolderName = "Amir",
                            IsActive = true,
                            Password = "1234",
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            Balance = 3000f,
                            CardNumber = "6104337864729130",
                            FailedLoginAttempts = 0,
                            HolderName = "Leila",
                            IsActive = true,
                            Password = "1234",
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            Balance = 6000f,
                            CardNumber = "6037701523192418",
                            FailedLoginAttempts = 0,
                            HolderName = "Sara",
                            IsActive = true,
                            Password = "1234",
                            UserId = 4
                        },
                        new
                        {
                            Id = 5,
                            Balance = 5000f,
                            CardNumber = "6037701923372541",
                            FailedLoginAttempts = 0,
                            HolderName = "Miko",
                            IsActive = true,
                            Password = "1234",
                            UserId = 5
                        });
                });

            modelBuilder.Entity("HW_Week15.Entities.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<string>("DestinationCardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsSuccessful")
                        .HasColumnType("bit");

                    b.Property<string>("SourceCardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DestinationCardNumber");

                    b.HasIndex("SourceCardNumber");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("HW_Week15.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "elahe@gmail.com",
                            UserName = "Elahe"
                        },
                        new
                        {
                            Id = 2,
                            Email = "amir@gmail.com",
                            UserName = "Amir"
                        },
                        new
                        {
                            Id = 3,
                            Email = "leila@gmail.com",
                            UserName = "Leila"
                        },
                        new
                        {
                            Id = 4,
                            Email = "sara@gmail.com",
                            UserName = "Sara"
                        },
                        new
                        {
                            Id = 5,
                            Email = "miko@gmail.com",
                            UserName = "Miko"
                        });
                });

            modelBuilder.Entity("HW_Week15.Entities.Card", b =>
                {
                    b.HasOne("HW_Week15.Entities.User", "User")
                        .WithMany("Cards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("HW_Week15.Entities.Transaction", b =>
                {
                    b.HasOne("HW_Week15.Entities.Card", "DestinationCard")
                        .WithMany("DestinationTransactions")
                        .HasForeignKey("DestinationCardNumber")
                        .HasPrincipalKey("CardNumber")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HW_Week15.Entities.Card", "SourceCard")
                        .WithMany("SourceTransactions")
                        .HasForeignKey("SourceCardNumber")
                        .HasPrincipalKey("CardNumber")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DestinationCard");

                    b.Navigation("SourceCard");
                });

            modelBuilder.Entity("HW_Week15.Entities.Card", b =>
                {
                    b.Navigation("DestinationTransactions");

                    b.Navigation("SourceTransactions");
                });

            modelBuilder.Entity("HW_Week15.Entities.User", b =>
                {
                    b.Navigation("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}
