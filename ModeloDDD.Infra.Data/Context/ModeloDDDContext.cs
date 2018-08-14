using Microsoft.EntityFrameworkCore;
using ModeloDDD.Domain.Entities;
using ModeloDDD.Infra.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;


namespace ModeloDDD.Infra.Data.Context
{
    public class ModeloDDDContext : DbContext
    {
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer($@"Data Source=.;Initial Catalog=ModeloApi;User id=[USUARIO];password=[SENHA]");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(new UserMap().Configure);
        }
    }
}
