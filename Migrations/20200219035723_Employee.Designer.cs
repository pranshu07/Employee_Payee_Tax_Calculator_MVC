﻿// <auto-generated />
using Employee_Payee_Tax_Calculator_MVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Employee_Payee_Tax_Calculator_MVC.Migrations
{
    [DbContext(typeof(Employee_Payee_Tax_Calculator_DBContext))]
    [Migration("20200219035723_Employee")]
    partial class Employee
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Employee_Payee_Tax_Calculator_MVC.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("Employee_Payee_Tax_Calculator_MVC.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SalaryPerAnnum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TaxCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Employee_Payee_Tax_Calculator_MVC.Models.SalaryPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("CalculatedTax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("SalaryPayment");
                });

            modelBuilder.Entity("Employee_Payee_Tax_Calculator_MVC.Models.TaxTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TaxCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TaxPercentage")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("TaxTable");
                });

            modelBuilder.Entity("Employee_Payee_Tax_Calculator_MVC.Models.Employee", b =>
                {
                    b.HasOne("Employee_Payee_Tax_Calculator_MVC.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Employee_Payee_Tax_Calculator_MVC.Models.SalaryPayment", b =>
                {
                    b.HasOne("Employee_Payee_Tax_Calculator_MVC.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
