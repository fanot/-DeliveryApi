namespace WebApi.Helpers;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Net;
using WebApi.Entities;
using WebApi.Models.Users;

public class DataContext : DbContext

{
    protected readonly IConfiguration Configuration;

    public DbSet<Users> Users { get; set; }
    public DbSet<Dish> Dish { get; set; }

    public DbSet<Cart> Cart { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<RatingScore> RatingScore { get; set; }



    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sql server database
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
    }
   /* public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        //Database.EnsureCreated();
    }*/
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new DbInitializer(modelBuilder).Seed();
    }
    
}