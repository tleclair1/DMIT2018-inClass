﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindConsole.Entities;

namespace WestWindConsole.DAL
{
    public class WestWindContext : DbContext
    {
        // By default, Entity Framework (EF) will automatically re-create the database if it doesn't find one where the Connection String is pointing.
        public WestWindContext() : base("name=WWdb")
        {
            // TODO: Demonstrate null database initializer
            // We set the database initializer inside the cpnstructor of our DbContext class.
            // Setting it to null will prevent Entity Framework from re-creating the databse if it can't find it (which is what we want most of the time).
            // An alternative place to "turn off" or disable database initialization is in the web.config or app.config file.
            Database.SetInitializer<WestWindContext>(null);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTerritory> EmployeeTerritories { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Shipment> Shipments { get; set; }



        public DbSet<Address> Addresses { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Territory> Territories { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<ManifestItem> ManifestItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }


        // TODO: Practice - Add entities and DbSet<> properties for the remaining tables

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //The OnModeCreating method is where mapping information between the entities and the actual database can be done in addition to or in place of the mapping that happens via attributes on the Entity class members. It's a place for more complex data modeling of the database tables / entities.
            base.OnModelCreating(modelBuilder);
        }
    }
}
