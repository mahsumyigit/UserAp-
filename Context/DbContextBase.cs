using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using UserApı.Models.Entity;

namespace UserApı
{
    public class DbContextBase:DbContext
    {
        public DbSet<User>? Users { get; set; }

        public DbContextBase(DbContextOptions<DbContextBase> options) :
        base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.UseSerialColumns();
        }


        public static void TableBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Surname).IsRequired();
                entity.Property(e => e.StudentNumber).IsRequired();

            });
        }
    }
}

