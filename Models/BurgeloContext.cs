using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Login.Models;

namespace MVC.Models;

public class BurgeloContext : DbContext//IdentityDbContext<UserModel>
{
    public BurgeloContext(DbContextOptions<BurgeloContext> options) : base(options)
    {
        //....
    }
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Duyệt qua các bảng rồi xóa đi tiền tố AspNet
        // foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        // {
        //     var tableName = entityType.GetTableName();
        //     if (tableName.StartsWith("AspNet"))
        //     {
        //         entityType.SetTableName(tableName.Substring(6));
        //     }
        // }
    }
    public DbSet<ProductModel> products { get; set; }
    public DbSet<CategoryModel> categories { get; set; }
}