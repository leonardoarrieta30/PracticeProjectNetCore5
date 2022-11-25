using Microsoft.EntityFrameworkCore;
using WebAppplication.Infraestruture.Models;

namespace WebAppplication.Infraestruture.Context;

public class ClientDBContext : DbContext
{
    public ClientDBContext()
    {
    }
    
    public ClientDBContext(DbContextOptions<ClientDBContext> options) : base(options)
    {
    }
    
    public DbSet<Client>  Clients { get; set; } 
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 30));
            optionsBuilder.UseMySql("server=localhost;user=root;password=LaUpc123*;database=clientDB;", serverVersion);
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);


        builder.Entity<Client>().ToTable("Clients");
        builder.Entity<Client>().HasKey(p => p.Id);
        builder.Entity<Client>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        
        builder.Entity<Client>().Property(c => c.Name).IsRequired().HasMaxLength(60);
        
        
    }





}