namespace GameMastersToolsWeb.Models
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
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Campaign> Campaign { get; set; }
        public virtual DbSet<Chapter> Chapter { get; set; }
        public virtual DbSet<Encounter> Encounter { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<LoreCategory> LoreCategory { get; set; }
        public virtual DbSet<LoreSubject> LoreSubject { get; set; }
        public virtual DbSet<NPC> NPC { get; set; }
        public virtual DbSet<Obstacle> Obstacle { get; set; }
        public virtual DbSet<PC> PC { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Campaign>()
                .HasMany(e => e.Chapter)
                .WithRequired(e => e.Campaign)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Encounter>()
                .HasMany(e => e.Obstacle)
                .WithRequired(e => e.Encounter)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoreCategory>()
                .HasMany(e => e.LoreSubject)
                .WithRequired(e => e.LoreCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserPassword)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Campaign)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Encounter)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Item)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Location)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.LoreCategory)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.NPC)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.PC)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
