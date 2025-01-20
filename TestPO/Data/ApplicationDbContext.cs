using Microsoft.EntityFrameworkCore;
using System;
using TestPO.Models;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Sale> Sales { get; set; }

    public string DbPath { get; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={database.db}");

public DbSet<TestPO.Models.Feedback> Feedback { get; set; } = default!;
}

