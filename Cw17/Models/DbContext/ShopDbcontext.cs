using Cw17.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cw17.Models.DbContext;

public class ShopDbcontext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<Product> products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<User> Users { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer
            (@"Server=DESKTOP-78B19T2\SQLEXPRESS; Initial Catalog=HW_17; User Id=sa; Password=13771377; TrustServerCertificate=True;");
    }

}