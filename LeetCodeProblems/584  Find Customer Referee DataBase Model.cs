using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LeetCodeProblems_584 : DbContext
{
    public DbSet<Customer> Customer { get; set; }

    //SQL Server
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=localhost\\SQLEXPRESS01;Database=LeetCodeProblems_584;Trusted_Connection=True;TrustServerCertificate=True;");
    }

}


public class Customer
{
    [Key]
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Referee_id { get; set; }
}