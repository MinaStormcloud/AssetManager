using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AssetManager.Models;

namespace AssetManager.Data
{
    public class AssetManagerContext : DbContext
    {
        public AssetManagerContext (DbContextOptions<AssetManagerContext> options)
            : base(options)
        {
        }

        public DbSet<AssetManager.Models.Device> Device { get; set; } = default!;
    }
}
