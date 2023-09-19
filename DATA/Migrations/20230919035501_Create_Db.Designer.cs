﻿// <auto-generated />
using DATA.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace DATA.Migrations
{
    [DbContext(typeof(LapDbContext))]
    [Migration("20230919035501_Create_Db")]
    partial class Create_Db
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DATA.Entity.Battery", b =>
                {
                    b.Property<string>("ID")
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR2(30)");

                    b.Property<string>("Laptop_DetailID")
                        .HasColumnType("NVARCHAR2(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<int>("Status")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("ID");

                    b.HasIndex("Laptop_DetailID");

                    b.ToTable("Batteries");
                });

            modelBuilder.Entity("DATA.Entity.Category", b =>
                {
                    b.Property<string>("ID")
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR2(30)");

                    b.Property<string>("LaptopID")
                        .HasColumnType("NVARCHAR2(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR2(30)");

                    b.Property<int>("Status")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("ID");

                    b.HasIndex("LaptopID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DATA.Entity.Laptop", b =>
                {
                    b.Property<string>("ID")
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR2(30)");

                    b.Property<string>("IdCat")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR2(30)");

                    b.Property<string>("Laptop_DetailID")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR2(30)");

                    b.Property<decimal>("Price")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<int>("Status")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("ID");

                    b.HasIndex("Laptop_DetailID");

                    b.ToTable("Laptops");
                });

            modelBuilder.Entity("DATA.Entity.Laptop_Detail", b =>
                {
                    b.Property<string>("ID")
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR2(30)");

                    b.Property<decimal>("COGS")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<decimal>("Hight")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<string>("IdBattery")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR2(30)");

                    b.Property<string>("IdCam")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR2(30)");

                    b.Property<string>("IdLap")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR2(30)");

                    b.Property<string>("IdMain")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR2(30)");

                    b.Property<string>("IdNsx")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR2(30)");

                    b.Property<string>("IdRam")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR2(30)");

                    b.Property<string>("IdSSD")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR2(30)");

                    b.Property<string>("IdScren")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR2(30)");

                    b.Property<string>("IdVga")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR2(30)");

                    b.Property<decimal>("Price")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<int>("Quatity")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Seri")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("NVARCHAR2(20)");

                    b.Property<int>("Status")
                        .HasColumnType("NUMBER(10)");

                    b.Property<decimal>("Weight")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<decimal>("leght")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.HasKey("ID");

                    b.ToTable("laptop_Details");
                });

            modelBuilder.Entity("DATA.Entity.Main", b =>
                {
                    b.Property<string>("ID")
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR2(30)");

                    b.Property<string>("Laptop_DetailID")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR2(30)");

                    b.Property<decimal>("Price")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<int>("Status")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("ID");

                    b.HasIndex("Laptop_DetailID");

                    b.ToTable("Mains");
                });

            modelBuilder.Entity("DATA.Entity.Producer", b =>
                {
                    b.Property<string>("ID")
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR2(30)");

                    b.Property<string>("Laptop_DetailID")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.Property<int>("Status")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("ID");

                    b.HasIndex("Laptop_DetailID");

                    b.ToTable("Producers");
                });

            modelBuilder.Entity("DATA.Entity.Ram", b =>
                {
                    b.Property<string>("ID")
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR2(30)");

                    b.Property<string>("Laptop_DetailID")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<int>("Status")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("ID");

                    b.HasIndex("Laptop_DetailID");

                    b.ToTable("Rams");
                });

            modelBuilder.Entity("DATA.Entity.Screen", b =>
                {
                    b.Property<string>("ID")
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR2(30)");

                    b.Property<string>("Laptop_DetailID")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<int>("Status")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("ID");

                    b.HasIndex("Laptop_DetailID");

                    b.ToTable("Screens");
                });

            modelBuilder.Entity("DATA.Entity.SSD", b =>
                {
                    b.Property<string>("ID")
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR2(30)");

                    b.Property<string>("Laptop_DetailID")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<int>("Status")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("ID");

                    b.HasIndex("Laptop_DetailID");

                    b.ToTable("SSDs");
                });

            modelBuilder.Entity("DATA.Entity.VGA", b =>
                {
                    b.Property<string>("ID")
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR2(30)");

                    b.Property<string>("Laptop_DetailID")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<int>("Status")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("ID");

                    b.HasIndex("Laptop_DetailID");

                    b.ToTable("VGAs");
                });

            modelBuilder.Entity("DATA.Entity.Webcam", b =>
                {
                    b.Property<string>("ID")
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR2(30)");

                    b.Property<string>("Laptop_DetailID")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<int>("Status")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("ID");

                    b.HasIndex("Laptop_DetailID");

                    b.ToTable("Webcams");
                });

            modelBuilder.Entity("DATA.Entity.Battery", b =>
                {
                    b.HasOne("DATA.Entity.Laptop_Detail", "Laptop_Detail")
                        .WithMany("Battery")
                        .HasForeignKey("Laptop_DetailID");

                    b.Navigation("Laptop_Detail");
                });

            modelBuilder.Entity("DATA.Entity.Category", b =>
                {
                    b.HasOne("DATA.Entity.Laptop", "Laptop")
                        .WithMany("Categories")
                        .HasForeignKey("LaptopID");

                    b.Navigation("Laptop");
                });

            modelBuilder.Entity("DATA.Entity.Laptop", b =>
                {
                    b.HasOne("DATA.Entity.Laptop_Detail", "Laptop_Detail")
                        .WithMany("Laptop")
                        .HasForeignKey("Laptop_DetailID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Laptop_Detail");
                });

            modelBuilder.Entity("DATA.Entity.Main", b =>
                {
                    b.HasOne("DATA.Entity.Laptop_Detail", "Laptop_Detail")
                        .WithMany("Main")
                        .HasForeignKey("Laptop_DetailID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Laptop_Detail");
                });

            modelBuilder.Entity("DATA.Entity.Producer", b =>
                {
                    b.HasOne("DATA.Entity.Laptop_Detail", "Laptop_Detail")
                        .WithMany("producer")
                        .HasForeignKey("Laptop_DetailID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Laptop_Detail");
                });

            modelBuilder.Entity("DATA.Entity.Ram", b =>
                {
                    b.HasOne("DATA.Entity.Laptop_Detail", "Laptop_Detail")
                        .WithMany("Ram")
                        .HasForeignKey("Laptop_DetailID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Laptop_Detail");
                });

            modelBuilder.Entity("DATA.Entity.Screen", b =>
                {
                    b.HasOne("DATA.Entity.Laptop_Detail", "Laptop_Detail")
                        .WithMany("Screen")
                        .HasForeignKey("Laptop_DetailID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Laptop_Detail");
                });

            modelBuilder.Entity("DATA.Entity.SSD", b =>
                {
                    b.HasOne("DATA.Entity.Laptop_Detail", "Laptop_Detail")
                        .WithMany("SSD")
                        .HasForeignKey("Laptop_DetailID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Laptop_Detail");
                });

            modelBuilder.Entity("DATA.Entity.VGA", b =>
                {
                    b.HasOne("DATA.Entity.Laptop_Detail", "Laptop_Detail")
                        .WithMany("VGA")
                        .HasForeignKey("Laptop_DetailID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Laptop_Detail");
                });

            modelBuilder.Entity("DATA.Entity.Webcam", b =>
                {
                    b.HasOne("DATA.Entity.Laptop_Detail", "Laptop_Detail")
                        .WithMany("Webcam")
                        .HasForeignKey("Laptop_DetailID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Laptop_Detail");
                });

            modelBuilder.Entity("DATA.Entity.Laptop", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("DATA.Entity.Laptop_Detail", b =>
                {
                    b.Navigation("Battery");

                    b.Navigation("Laptop");

                    b.Navigation("Main");

                    b.Navigation("Ram");

                    b.Navigation("SSD");

                    b.Navigation("Screen");

                    b.Navigation("VGA");

                    b.Navigation("Webcam");

                    b.Navigation("producer");
                });
#pragma warning restore 612, 618
        }
    }
}
