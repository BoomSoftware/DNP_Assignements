using FamilyWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyWebAPI.Persistence
{
    public class FamilyDbContext : DbContext
    {
        // public DbSet<Adult> Adults { get; set; }
        // public DbSet<Child> Children { get; set; }
        // public DbSet<ChildInterest> ChildInterests { get; set; }
        // public DbSet<Family> Families { get; set; }
        // public DbSet<Interest> Interests { get; set; }
        // public DbSet<Person> Persons { get; set; }
        // public DbSet<Pet> Pets { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<APIUser> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;port=3606;database=assignment4;user=root;password=29312112");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<ChildInterest>()
                .HasKey(ci => new {ci.ChildId, ci.InterestId});

            modelBuilder.Entity<Family>()
                .HasKey(fam => new {fam.StreetName, fam.HouseNumber});

            modelBuilder.Entity<ChildInterest>()
                .HasOne(ci => ci.Child)
                .WithMany(child => child.ChildInterests)
                .HasForeignKey(ci => ci.ChildId);

            modelBuilder.Entity<ChildInterest>()
                .HasOne(ci => ci.Interest)
                .WithMany(i => i.ChildInterests)
                .HasForeignKey(ci => ci.InterestId);
            // modelBuilder.Entity<Pet>(entity =>
            // {
            //     entity.HasKey(e => e.Id);
            //     entity.Property(e => e.Species).IsRequired();
            //     entity.Property(e => e.Name).IsRequired();
            //     entity.Property(e => e.Age).IsRequired();
            //     
            // });
            //
            // modelBuilder.Entity<Person>(entity =>
            // {
            //     entity.HasKey(e => e.Id);
            //     entity.Property(e => e.FirstName).IsRequired();
            //     entity.Property(e => e.LastName).IsRequired();
            //     entity.Property(e => e.HairColor).IsRequired();
            //     entity.Property(e => e.EyeColor).IsRequired();
            //     entity.Property(e => e.Age).IsRequired();
            //     entity.Property(e => e.Weight).IsRequired();
            //     entity.Property(e => e.Height).IsRequired();
            //     entity.Property(e => e.Sex).IsRequired();
            //
            // });
            //
            // modelBuilder.Entity<Child>(entity =>
            // {
            //     entity.Property(e => e.ChildInterests).IsRequired();
            //     entity.Property(e => e.Pets).IsRequired();
            // });
            //
            // modelBuilder.Entity<ChildInterest>(entity =>
            // {
            //     entity.HasKey(e => e.ChildId);
            //     entity.Property(e => e.Child).IsRequired();
            //     entity.Property(e => e.Interest).IsRequired();
            //     entity.Property(e => e.InterestId).IsRequired();
            //     
            // });
            //
            // modelBuilder.Entity<Family>(entity =>
            // {
            //     entity.HasKey(e => e.Id);
            //     entity.Property(e => e.StreetName).IsRequired();
            //     entity.Property(e => e.HouseNumber).IsRequired();
            //     entity.Property(e => e.Adults).IsRequired();
            //     entity.Property(e => e.Children).IsRequired();
            //     entity.Property(e => e.Pets).IsRequired();
            //     
            // });
            //
            // modelBuilder.Entity<Interest>(entity =>
            // {
            //     entity.HasKey(e => e.Type);
            //     entity.Property(e => e.ChildInterests).IsRequired();
            // });
            //
            // modelBuilder.Entity<Adult>(entity =>
            // {
            //     entity.Property(e => e.JobTitle).IsRequired();
            // });
        }
    }
}
