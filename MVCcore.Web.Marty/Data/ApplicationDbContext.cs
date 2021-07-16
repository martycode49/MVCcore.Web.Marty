using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCcore.Web.Marty.Models;

namespace MVCcore.Web.Marty.Data
{
    public class ApplicationDbContext : DbContext
    {   
        // Dependence Injection : create a constructor 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Category { get; set; }
    }
}
