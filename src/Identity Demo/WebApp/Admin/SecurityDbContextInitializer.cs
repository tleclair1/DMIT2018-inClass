﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Admin
{
    /// <summary>
    /// Provide functionality for setting up the database for the ApplicationDbContext.
    /// The specific
    /// </summary>
    internal class SecurityDbContextInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            // To "seed" a database is to provide it with some initial data when the database is created
            //base.Seed(context);

            #region Seed the security roles
            // We need ASP.Net's BLL equivalent for working with Roles
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context)); // Example of DI
            // DI - Dependency Injection is an OOP strategy to allow for decoupling for hard-coded dependencies in our layers
            // Create our security role
            roleManager.Create(new IdentityRole { Name = Settings.AdminRole });
            #endregion

            #region Seed the user
            // First, create the administrator for the site
            // 1) Grab some data from the configuration
            string adminEmail = ConfigurationManager.AppSettings["adminEmail"];
            string initalPassword = ConfigurationManager.AppSettings["adminPassword"];
            // 2) Create our BLL for managing users
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            // 3) Create our user
            var admin = new ApplicationUser
            {
                UserName = Settings.AdminUser,
                Email = adminEmail,
                EmailConfirmed = true,
                FirstName = "Website",
                LastName = "Administrator"
            };
            var result = userManager.Create(admin, initalPassword);
            // 4) Add the admin user to the security role for administrators
            if (result.Succeeded)
            {
                var user = userManager.FindByName(Settings.AdminUser);
                userManager.AddToRole(user.Id, Settings.AdminRole);
            }
            #endregion
        }
    }
}