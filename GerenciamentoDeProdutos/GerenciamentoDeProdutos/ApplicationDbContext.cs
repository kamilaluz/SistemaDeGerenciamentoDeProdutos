using GerenciamentoDeProdutos.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GerenciamentoDeProdutos
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<Produto> Produtos { get; set; }
    }
}
