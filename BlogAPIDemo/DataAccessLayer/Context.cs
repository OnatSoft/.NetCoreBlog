using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPIDemo.DataAccessLayer
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LAPTOP-ONATSOFT\\ONATSOFT;database=CoreBlogAPIDB; integrated security=true;");
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
