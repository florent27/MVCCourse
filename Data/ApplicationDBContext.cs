using BulkyDonetCore30.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulkyDonetCore30.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public ApplicationDBContext() : this(null)
        {
        }

        public DbSet<Category> Categories { get; set; }
    }
}