using FamilyWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyWebAPI.Persistence
{
    public class FamilyDbContext : DbContext
    {
        public DbSet<Adult> Adults { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<ChildInterest> ChildInterests { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Pet> Pets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;port=3306;database=assignment4;user=root;password=293113");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Pet>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Species).IsRequired();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Age).IsRequired();
                
            });
            
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName).IsRequired();
                entity.Property(e => e.LastName).IsRequired();
                entity.Property(e => e.HairColor).IsRequired();
                entity.Property(e => e.EyeColor).IsRequired();
                entity.Property(e => e.Age).IsRequired();
                entity.Property(e => e.Weight).IsRequired();
                entity.Property(e => e.Height).IsRequired();
                entity.Property(e => e.Sex).IsRequired();

            });
            
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Child>(entity =>
            {
                entity.Property(e => e.ChildInterests).IsRequired();
                entity.Property(e => e.Pets).IsRequired();
            });
            
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ChildInterest>(entity =>
            {
                entity.HasKey(e => e.ChildId);
                entity.Property(e => e.Child).IsRequired();
                entity.Property(e => e.Interest).IsRequired();
                entity.Property(e => e.InterestId).IsRequired();
                
            });
            
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Family>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.StreetName).IsRequired();
                entity.Property(e => e.HouseNumber).IsRequired();
                entity.Property(e => e.Adults).IsRequired();
                entity.Property(e => e.Children).IsRequired();
                entity.Property(e => e.Pets).IsRequired();
                
            });
            
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Interest>(entity =>
            {
                entity.HasKey(e => e.Type);
                entity.Property(e => e.ChildInterests).IsRequired();
            });
            
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Adult>(entity =>
            {
                entity.Property(e => e.JobTitle).IsRequired();
            });

        }
        
    }
}
