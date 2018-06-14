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

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Medida> Medida { get; set; }
    }
}
