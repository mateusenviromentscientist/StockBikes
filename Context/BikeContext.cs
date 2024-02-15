using Microsoft.EntityFrameworkCore;
using StockBikes.Context.Entities;

public class BikeDbContext : DbContext
{
    public DbSet<Bike> Bikes { get; set; }
    public DbSet<Seat> Seats { get; set; }
    public DbSet<Pedal> Pedals { get; set; }
    public DbSet<Frame> Frames { get; set; }
    public DbSet<Tube> Tubes { get; set; }
    public DbSet<Wheel> Wheels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("ConnectionString");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
        modelBuilder.Entity<Bike>()
            .HasOne(b => b.Seat)
            .WithMany()
            .HasForeignKey(b => b.SeatID);

        modelBuilder.Entity<Bike>()
            .HasOne(b => b.LeftPedal)
            .WithMany()
            .HasForeignKey(b => b.LeftPedalID);

        modelBuilder.Entity<Bike>()
            .HasOne(b => b.RightPedal)
            .WithMany()
            .HasForeignKey(b => b.RightPedalID);

        modelBuilder.Entity<Bike>()
            .HasOne(b => b.LeftWheel)
            .WithMany()
            .HasForeignKey(b => b.LeftWheelID);

        modelBuilder.Entity<Bike>()
            .HasOne(b => b.RightWheel)
            .WithMany()
            .HasForeignKey(b => b.RightWheelID);

        modelBuilder.Entity<Wheel>()
            .HasOne(w => w.Frame)
            .WithMany()
            .HasForeignKey(w => w.FrameID);

        modelBuilder.Entity<Wheel>()
            .HasOne(w => w.Tube)
            .WithMany()
            .HasForeignKey(w => w.TubeID);
    }
}
