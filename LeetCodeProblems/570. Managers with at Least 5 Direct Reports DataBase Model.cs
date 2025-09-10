using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LeetCodeProblems_570 : DbContext
{
    public DbSet<Employee> Employee { get; set; }

    // SQL Server configuration
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=localhost\\SQLEXPRESS01;Database=LeetCodeProblems_570;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .Property(e => e.Id)
            .ValueGeneratedNever();

        modelBuilder.Entity<Employee>()
            .Property(e => e.Department)
            .HasColumnType("varchar(255)");
    }
}

// Employee model class
public class Employee
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Department { get; set; }
    public int? ManagerId { get; set; }
}