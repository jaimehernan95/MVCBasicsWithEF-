using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCBasicsWithEF.Models;

namespace MVCBasicsWithEF.Data
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options): base(options)
        {

        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Game> Games { get; set; }
    }
}
