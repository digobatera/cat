using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cat.Models
{
    public class CatDetailContext : DbContext
    {
        public CatDetailContext(DbContextOptions<CatDetailContext> options) : base(options)
        { }

        public DbSet<CatDetail> CatDetails { get; set; }
    }

}
