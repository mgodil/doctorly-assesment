using Doctorly.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctorly.Infrastracture
{
    public class DoctorlyDbContext : DbContext
    {
        public DoctorlyDbContext(DbContextOptions<DoctorlyDbContext> options)
            : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendee>()
                 .HasOne(a => a.Event)
                 .WithMany(e => e.Attendees)
                 .HasForeignKey(a => a.EventId);
        }
        public DbSet<Attendee> Attendees => Set<Attendee>();
        public DbSet<Event> Events => Set<Event>();

    }
}
