using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class LeetCodeProblem : DbContext
{
    public DbSet<Products> products { get; set; }
    
    //SQL Server
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=localhost\\SQLEXPRESS01;Database=LeetCodeProblems;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Products>()
        .ToTable(t =>
        {
            t.HasCheckConstraint("CK_low_fats_Y_N", "[low_fats] IN ('Y', 'N')");
            t.HasCheckConstraint("CK_recyclable_Y_N", "[recyclable] IN ('Y', 'N')");
        });

    }


}

public class Products
{
    [Key]
    public int ProductId { get; set; }

    [Column(TypeName = "char(1)")]
    public char low_fats { get; set; }

    [Column(TypeName = "char(1)")]
    public char recyclable { get; set; }
}