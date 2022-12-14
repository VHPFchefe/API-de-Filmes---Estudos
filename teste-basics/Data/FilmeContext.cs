using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class FilmeContext: DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> opt) : base(opt)
        {

        }

        public DbSet<Filme> Filmes { get; set; }
    }
}
