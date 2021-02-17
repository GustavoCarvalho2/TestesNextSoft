using Microsoft.EntityFrameworkCore;
using TestesNextSoft.Models;

namespace TestesNextSoft.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        } 

        public DbSet<Clientes> Clientes { get; set; }

        public DbSet<Endereco> Endereco { get; set; }
    }
}