using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LeetCodeProblems_595 : DbContext
{
    public DbSet<World> World { get; set; }

    //SQL Server
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=localhost\\SQLEXPRESS01;Database=LeetCodeProblems_595;Trusted_Connection=True;TrustServerCertificate=True;");
    }

}


public class World
{
    [Key]
    public string? Name { get; set; }
    public int Id { get; set; }
    public string? Continent { get; set; }
    public int? Area { get; set; }
    public int? Population { get; set; }
    public double? Gdp { get; set; }
}