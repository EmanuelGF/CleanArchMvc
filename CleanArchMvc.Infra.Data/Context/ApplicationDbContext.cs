using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Added packages:
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.Tools
 */

/*  DbContext serves to interact with the database and is responsible for: 
 *  - Mapping models to the database.
    - Starting a session for this interaction with the database.
    - CRUD operations.
    - Cache.
    - Manage transactions
*/
namespace CleanArchMvc.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        //ctor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {    }

        //props
        //These will map the model class to the respective tables.
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        //Methods
        //Allows the model configuration using Fluent API
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            //This is going look for the configuration classes in the EntitiesConfiguration folder.
        }

    }
}

/* NOTES:
 In the aproach code first, EF Core follows the some conventions to generate the database
and the tables:
- The database will be created based on the connection string.
- To generate the tables it will verify the entities mapped in the context archive (ApplicationDbContext).
- It will generate the tables with the name defined with properties of type DbSet<T>.

 Fluent API will allow to correct some problems that arise when the database and tables are
automatically created. 
(This configuration is done in the classes in the EntitiesConfiguration folder)

 */