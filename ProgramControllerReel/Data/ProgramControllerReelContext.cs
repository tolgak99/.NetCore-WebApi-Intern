using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProgramControllerReel.Models
{
    public class ProgramControllerReelContext : DbContext
    {
        public ProgramControllerReelContext (DbContextOptions<ProgramControllerReelContext> options)
            : base(options)
        {
        }

        public DbSet<ProgramControllerReel.Models.Programs> Programs { get; set; }
    }
}
