using Carrefour.Domain.Models;
using Carrefour.Repository.DataSeeding;
using Microsoft.EntityFrameworkCore;
using System;

namespace Carrefour.Repository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //1 User Has Many Likes
            modelBuilder.Entity<Customer>()
                        .HasMany<Transaction>(C => C.Transactions)
                        .WithOne(T => T.Customer)
                        .HasForeignKey(T => T.CustomerID).OnDelete(DeleteBehavior.NoAction);

            // 1 to 1 relation
            modelBuilder.Entity<Transaction>()
                        .HasOne<TransactionType>(t => t.Type)
                        .WithOne(b => b.Transaction)
                        .HasForeignKey<TransactionType>(b => b.ID);

            modelBuilder.UserSeed();

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }

    }
}

