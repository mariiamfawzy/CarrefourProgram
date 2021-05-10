using Carrefour.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carrefour.Repository.DataSeeding
{
    public static class SeedingData
    {
        public static void UserSeed(this ModelBuilder modelBuilder)
        {
            //Customers List
            List<Customer> CustomersList = new List<Customer>() {
             new Customer
            {
                ID = 1,
                TotalXPoints = 200
            },

            new Customer
            {
                ID = 2,
                TotalXPoints = 400

            },

            new Customer
            {
                ID = 3,
                TotalXPoints = 600

            }

            };


            List<Transaction> TransactionsList = new List<Transaction>() {
            new Transaction
            {
                ID = 1,
                SpentAmount = 500,
                CreatedDate = DateTime.Now,
                CustomerID = 1,
                XPoints = 500
            },

            new Transaction
            {
                ID = 2,
                SpentAmount = 300,
                CreatedDate = DateTime.Now,
                CustomerID = 1,
                XPoints = 300
            },

            new Transaction
            {
                ID = 3,
                SpentAmount = 600,
                CreatedDate = DateTime.Now,
                CustomerID = 2,
                XPoints = 600
            }

            };

            List<TransactionType> TransactionTypesList = new List<TransactionType>() {
            new TransactionType
            {
                ID = 1,
                Type = "Purchase"
            },

            new TransactionType
            {
                ID = 2,
                Type = "Redeem"

            }
            };

            List<Configuration> ConfigsList = new List<Configuration>() {
            new Configuration
            {
                ID = 1,
                XFactor = 1,
                YFactor = 1
            }
            };



            modelBuilder.Entity<Customer>().HasData(
               CustomersList
            );

            modelBuilder.Entity<Transaction>().HasData(
               TransactionsList
            );

            modelBuilder.Entity<TransactionType>().HasData(
               TransactionTypesList
            );

            modelBuilder.Entity<Configuration>().HasData(
               ConfigsList
            );
        }
    }
}
