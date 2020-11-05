using Ev_T3_DIARS.Models.Maps;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ev_T3_DIARS.Models
{
    public class T3Context : DbContext
    {
        public DbSet<User> Users { get; set; }

        public T3Context(DbContextOptions<T3Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}
