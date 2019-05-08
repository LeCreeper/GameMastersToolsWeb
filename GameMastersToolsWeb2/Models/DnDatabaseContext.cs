namespace GameMastersToolsWeb2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DnDatabaseContext : DbContext
    {
        public DnDatabaseContext()
            : base("name=DnDatabaseContext")
        {
        }

        public virtual DbSet<Campaign> Campaigns { get; set; }
        public virtual DbSet<Chapter> Chapters { get; set; }
        public virtual DbSet<Encounter> Encounters { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<LoreCategory> LoreCategories { get; set; }
        public virtual DbSet<LoreSubject> LoreSubjects { get; set; }
        public virtual DbSet<NPC> NPCs { get; set; }
        public virtual DbSet<Obstacle> Obstacles { get; set; }
        public virtual DbSet<PC> PCs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Encounter>()
                .HasMany(e => e.Obstacles)
                .WithRequired(e => e.Encounter)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoreCategory>()
                .HasMany(e => e.LoreSubjects)
                .WithRequired(e => e.LoreCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserPassword)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Encounters)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Items)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Locations)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.LoreCategories)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.NPCs)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.PCs)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
