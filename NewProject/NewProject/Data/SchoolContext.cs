using Microsoft.EntityFrameworkCore;
using NewProject.Models;
using System.Collections.Generic;

namespace NewProject.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }


}
