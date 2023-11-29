using Doctorly.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctorly.Infrastracture
{
    public class DoctorlyDbContext : DbContext
    {
        public DoctorlyDbContext(DbContextOptions<DoctorlyDbContext> options)
            :base(options)
        {

        }

        public DoctorlyDbContext()
        {

        }

        public DbSet<Member> GetMembers => Set<Member>();
    }
}
