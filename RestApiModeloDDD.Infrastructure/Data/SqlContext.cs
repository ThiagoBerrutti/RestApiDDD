using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RestApiModeloDDD.Domain.Entities;
using System;
using System.IO;
using System.Linq;

namespace RestApiModeloDDD.Infrastructure.Data
{
    public class SqlContext : DbContext
    {        
        public SqlContext()
        {
        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            
                //builder.UseSqlServer("Server=LAPTOP-EVCD5202\\SQLEXPRESS;Database=RestApiModeloDDD;User Id=sa;Password=1q2w3e4r@#$;");
                //builder.UseSqlServer("Server=LAPTOP-EVCD5202\\SQLEXPRESS, 1433;Database=RestApiModeloDDD;User Id=sa;Password=1q2w3e4r@#$");
            
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        

        public override int SaveChanges()
        {
            string propNameDataCadastro = "DataCadastro";
            var dataCadastros = ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty(propNameDataCadastro) != null);
            foreach (var entry in dataCadastros)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property(propNameDataCadastro).CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property(propNameDataCadastro).IsModified = false;
                }
            }

            return base.SaveChanges();
        }
    }
}