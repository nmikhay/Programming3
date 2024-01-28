using Microsoft.EntityFrameworkCore;
using StudentServices.Models;
using System.Collections.Generic;

namespace StudentServices.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}


