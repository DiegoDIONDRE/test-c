using BelezaNaWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BelezaNaWeb.Infraestructure.Context
{
    public class BelezaNaWebContext: DbContext
    {
        public BelezaNaWebContext (DbContextOptions<BelezaNaWebContext> dbContext)
            : base(dbContext) { }

        public DbSet<ProdutoEntity> Produto { get; set; }
        public DbSet<ProdutoArmazemEntity> ProdutoArmazem { get; set; }
        public DbSet<ProdutoInventarioEntity> ProdutoInventario { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ProdutoEntity>().HasData(
                new ProdutoEntity { Sku = "0001", Name = "Produto 0001" },
                new ProdutoEntity { Sku = "0002", Name = "Produto 0002" },
                new ProdutoEntity { Sku = "0003", Name = "Produto 0003" },
                new ProdutoEntity { Sku = "0004", Name = "Produto 0004" },
                new ProdutoEntity { Sku = "0005", Name = "Produto 0005" }
            );

            builder.Entity<ProdutoInventarioEntity>().HasData(
                new ProdutoInventarioEntity { Sku = "0001", Quantity = 0, IsMarketable = false },
                new ProdutoInventarioEntity { Sku = "0002", Quantity = 10, IsMarketable = true },
                new ProdutoInventarioEntity { Sku = "0003", Quantity = 20, IsMarketable = true },
                new ProdutoInventarioEntity { Sku = "0004", Quantity = 30, IsMarketable = true },
                new ProdutoInventarioEntity { Sku = "0005", Quantity = 40, IsMarketable = true }
            );

            builder.Entity<ProdutoArmazemEntity>().HasData(
                new ProdutoArmazemEntity { Sku = "0001", Quantity = 0, Locality = "SP", Type = "ECOMMERCE" },
                
                new ProdutoArmazemEntity { Sku = "0002", Quantity = 5, Locality = "RJ", Type = "PHYSICAL_STORE" },
                new ProdutoArmazemEntity { Sku = "0002", Quantity = 5, Locality = "SP", Type = "ECOMMERCE" },
                
                new ProdutoArmazemEntity { Sku = "0003", Quantity = 5, Locality = "SP", Type = "PHYSICAL_STORE" },
                new ProdutoArmazemEntity { Sku = "0003", Quantity = 15, Locality = "SP", Type = "ECOMMERCE" },
                
                new ProdutoArmazemEntity { Sku = "0004", Quantity = 15, Locality = "SP", Type = "ECOMMERCE" },
                new ProdutoArmazemEntity { Sku = "0004", Quantity = 5, Locality = "RJ", Type = "PHYSICAL_STORE" },
                new ProdutoArmazemEntity { Sku = "0004", Quantity = 10, Locality = "MG", Type = "PHYSICAL_STORE" },
                
                new ProdutoArmazemEntity { Sku = "0005", Quantity = 20, Locality = "SP", Type = "ECOMMERCE" },
                new ProdutoArmazemEntity { Sku = "0005", Quantity = 5, Locality = "RJ", Type = "PHYSICAL_STORE" },
                new ProdutoArmazemEntity { Sku = "0005", Quantity = 5, Locality = "MG", Type = "PHYSICAL_STORE" },
                new ProdutoArmazemEntity { Sku = "0005", Quantity = 10, Locality = "ES", Type = "PHYSICAL_STORE" }
            );
        }
    }
}
