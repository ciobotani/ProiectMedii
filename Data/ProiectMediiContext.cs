using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProiectMedii.Models;

namespace ProiectMedii.Data
{
    public class ProiectMediiContext : DbContext
    {
        public ProiectMediiContext (DbContextOptions<ProiectMediiContext> options)
            : base(options)
        {
        }

        public DbSet<ProiectMedii.Models.Student> Student { get; set; }

        public DbSet<ProiectMedii.Models.Curs> Curs { get; set; }

        public DbSet<ProiectMedii.Models.Inrolare> Inrolare { get; set; }
    }
}
