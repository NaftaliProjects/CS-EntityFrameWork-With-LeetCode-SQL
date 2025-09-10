using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LeetCodeProblems_1148 : DbContext
{
    public DbSet<Views> Views { get; set; }

    //SQL Server
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=localhost\\SQLEXPRESS01;Database=LeetCodeProblems_1148;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    /*
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Views>().HasNoKey();
    }
    */
}


public class Views
{
    [Key]
    public int Id { get; set; }
    public int      Article_id { get; set; }
    public int      Author_id { get; set; }
    public int      Viewer_id { get; set; }
    public DateTime View_date { get; set; }

}