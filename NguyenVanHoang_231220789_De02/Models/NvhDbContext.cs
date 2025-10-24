using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace NguyenVanHoang_231220789_De02.Models
{
    public class NvhDbContext : DbContext
    {
        public NvhDbContext(DbContextOptions<NvhDbContext> options)
            : base(options) { }

        public DbSet<NvhCatalog> NvhCatalogs { get; set; }
    }
}