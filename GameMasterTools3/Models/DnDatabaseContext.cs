namespace GameMasterTools3.Models
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
        public virtual DbSet<CampaignPC> CampaignPC { get; set; }
        public virtual DbSet<Chapter> Chapter { get; set; }
        public virtual DbSet<Encounter> Encounter { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<LoreCategory> LoreCategory { get; set; }
        public virtual DbSet<LoreSubject> LoreSubject { get; set; }
        public virtual DbSet<NPC> NPC { get; set; }
        public virtual DbSet<Obstacle> Obstacle { get; set; }
        public virtual DbSet<PC> PC { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Campaign>()
                .HasMany(e => e.CampaignPC)
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

            modelBuilder.Entity<PC>()
                .HasMany(e => e.CampaignPC)
                .WithRequired(e => e.PC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.UserPassword)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Encounter)
                .WithRequired(e => e.Users)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Item)
                .WithRequired(e => e.Users)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Location)
                .WithRequired(e => e.Users)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.LoreCategory)
                .WithRequired(e => e.Users)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.NPC)
                .WithRequired(e => e.Users)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.PC)
                .WithRequired(e => e.Users)
                .WillCascadeOnDelete(false);
        }
    }
}
