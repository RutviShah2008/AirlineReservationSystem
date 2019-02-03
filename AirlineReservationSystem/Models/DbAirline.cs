namespace AirlineReservationSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbAirline : DbContext
    {
        public DbAirline()
            : base("name=DbAirline1")
        {
        }

        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Jet> Jets { get; set; }
        public virtual DbSet<Passenger> Passengers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>()
                .Property(e => e.FlightSource)
                .IsUnicode(false);

            modelBuilder.Entity<Flight>()
                .Property(e => e.FlightDestination)
                .IsUnicode(false);

            modelBuilder.Entity<Flight>()
                .Property(e => e.FlightTime)
                .IsUnicode(false);

            modelBuilder.Entity<Flight>()
                .HasMany(e => e.Tickets)
                .WithOptional(e => e.Flight)
                .HasForeignKey(e => e.FlightType);

            modelBuilder.Entity<Jet>()
                .Property(e => e.JetName)
                .IsUnicode(false);

            modelBuilder.Entity<Jet>()
                .Property(e => e.JetType)
                .IsUnicode(false);

            modelBuilder.Entity<Jet>()
                .HasMany(e => e.Flights)
                .WithOptional(e => e.Jet)
                .HasForeignKey(e => e.FlightJetID);

            modelBuilder.Entity<Passenger>()
                .Property(e => e.PassengerName)
                .IsUnicode(false);

            modelBuilder.Entity<Ticket>()
                .Property(e => e.TicketType)
                .IsUnicode(false);
        }
    }
}
