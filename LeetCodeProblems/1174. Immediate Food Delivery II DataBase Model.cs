using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LeetCodeProblems_1174 : DbContext
{
    public DbSet<Delivery> Delivery { get; set; }

    //SQL Server
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=localhost\\SQLEXPRESS01;Database=LeetCodeProblems_1174;Trusted_Connection=True;TrustServerCertificate=True;");
    }

}


public class Delivery
{
    [Key]
    public int Delivery_id { get; set; }
    public int Customer_id { get; set; }
    public DateTime? Order_date { get; set; }
    public DateTime? Customer_pref_delivery_date { get; set; }
   
}