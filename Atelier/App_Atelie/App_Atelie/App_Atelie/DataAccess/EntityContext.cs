using App_Atelie.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App_Atelie.DataAccess
{
    public class EntityContext : DbContext
    {
        const string dbFilePath = "database.db";

        public EntityContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = DependencyService.Get<IBaseFilePath>().GetBaseFilePath(dbFilePath);
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.MapRelations(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void MapRelations(ModelBuilder modelBuilder)
        {
            // Pedido
            modelBuilder.Entity<Pedido>().Property(p => p.IdCliente);
            modelBuilder.Entity<Pedido>().HasOne(p => p.Cliente).WithMany(p => p.Pedidos).HasForeignKey(p => p.IdCliente);
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
    }
}
