using library_MS_LV.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_MS_LV.DatabaseConf
{
    internal class LibraryContext : DbContext
    {
        static readonly string connectionString = "Server=localhost; User ID=root; Password=; Database=libraryms;";

        public DbSet<Admin> Admins { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}

