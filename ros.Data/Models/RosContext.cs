namespace ros.Data.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RosContext : DbContext
    {
        public RosContext()
            : base("name=RosContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Boats> Boats { get; set; }
        public virtual DbSet<Clubs> Clubs { get; set; }
        public virtual DbSet<ContactAddresses> ContactAddresses { get; set; }
        public virtual DbSet<ContactPersons> ContactPersons { get; set; }
        public virtual DbSet<ContactTypes> ContactTypes { get; set; }
        public virtual DbSet<Entries> Entries { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<RaceEvents> RaceEvents { get; set; }
        public virtual DbSet<RaceEventTeams> RaceEventTeams { get; set; }
        public virtual DbSet<RegattaEntries> RegattaEntries { get; set; }
        public virtual DbSet<Regattas> Regattas { get; set; }
        public virtual DbSet<RegisteredUsers> RegisteredUsers { get; set; }
        public virtual DbSet<RegisteredUserSocialEvents> RegisteredUserSocialEvents { get; set; }
        public virtual DbSet<Results> Results { get; set; }
        public virtual DbSet<SocialEvents> SocialEvents { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Boats>()
                .Property(e => e.BoatName)
                .IsUnicode(false);

            modelBuilder.Entity<Boats>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Boats>()
                .Property(e => e.BoatType)
                .IsUnicode(false);

            modelBuilder.Entity<Boats>()
                .HasMany(e => e.Results)
                .WithRequired(e => e.Boats)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Clubs>()
                .Property(e => e.ClubName)
                .IsUnicode(false);

            modelBuilder.Entity<Clubs>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Clubs>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Clubs>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Clubs>()
                .Property(e => e.LogoUrl)
                .IsUnicode(false);

            modelBuilder.Entity<Clubs>()
                .Property(e => e.WebSiteUrl)
                .IsUnicode(false);

            modelBuilder.Entity<Clubs>()
                .HasMany(e => e.ContactAddresses)
                .WithRequired(e => e.Clubs)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Clubs>()
                .HasMany(e => e.Entries)
                .WithRequired(e => e.Clubs)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Clubs>()
                .HasMany(e => e.Regattas)
                .WithRequired(e => e.Clubs)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Clubs>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Clubs)
                .Map(m => m.ToTable("ClubUsers").MapLeftKey("ClubId").MapRightKey("UserId"));

            modelBuilder.Entity<ContactAddresses>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<ContactAddresses>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<ContactAddresses>()
                .Property(e => e.ContactAddressType)
                .IsUnicode(false);

            modelBuilder.Entity<ContactAddresses>()
                .Property(e => e.Street)
                .IsUnicode(false);

            modelBuilder.Entity<ContactAddresses>()
                .HasMany(e => e.Events)
                .WithRequired(e => e.ContactAddresses)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ContactAddresses>()
                .HasMany(e => e.Regattas)
                .WithRequired(e => e.ContactAddresses)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ContactPersons>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<ContactPersons>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<ContactPersons>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<ContactPersons>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<ContactPersons>()
                .HasMany(e => e.Clubs)
                .WithRequired(e => e.ContactPersons)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ContactPersons>()
                .HasMany(e => e.Regattas)
                .WithRequired(e => e.ContactPersons)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ContactPersons>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.ContactPersons)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ContactTypes>()
                .Property(e => e.TypeName)
                .IsUnicode(false);

            modelBuilder.Entity<ContactTypes>()
                .HasMany(e => e.ContactPersons)
                .WithRequired(e => e.ContactTypes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Entries>()
                .Property(e => e.EntryName)
                .IsUnicode(false);

            modelBuilder.Entity<Entries>()
                .HasMany(e => e.RegattaEntries)
                .WithRequired(e => e.Entries)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Entries>()
                .HasMany(e => e.RegisteredUsers)
                .WithRequired(e => e.Entries)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Entries>()
                .HasMany(e => e.Teams)
                .WithRequired(e => e.Entries)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Events>()
                .Property(e => e.EventName)
                .IsUnicode(false);

            modelBuilder.Entity<Events>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Events>()
                .HasOptional(e => e.RaceEvents)
                .WithRequired(e => e.Events);

            modelBuilder.Entity<Events>()
                .HasOptional(e => e.SocialEvents)
                .WithRequired(e => e.Events);

            modelBuilder.Entity<RaceEvents>()
                .HasMany(e => e.RaceEventTeams)
                .WithRequired(e => e.RaceEvents)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RaceEvents>()
                .HasMany(e => e.Results)
                .WithRequired(e => e.RaceEvents)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RaceEventTeams>()
                .Property(e => e.StartLocation)
                .IsUnicode(false);

            modelBuilder.Entity<RaceEventTeams>()
                .Property(e => e.EndLocation)
                .IsUnicode(false);

            modelBuilder.Entity<Regattas>()
                .Property(e => e.RegattaName)
                .IsUnicode(false);

            modelBuilder.Entity<Regattas>()
                .Property(e => e.RegattaDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Regattas>()
                .HasMany(e => e.Events)
                .WithRequired(e => e.Regattas)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Regattas>()
                .HasMany(e => e.RegattaEntries)
                .WithRequired(e => e.Regattas)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RegisteredUsers>()
                .HasMany(e => e.RegisteredUserSocialEvents)
                .WithRequired(e => e.RegisteredUsers)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RegisteredUsers>()
                .HasMany(e => e.Teams)
                .WithRequired(e => e.RegisteredUsers)
                .HasForeignKey(e => e.SkipperId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RegisteredUsers>()
                .HasMany(e => e.Teams1)
                .WithMany(e => e.RegisteredUsers1)
                .Map(m => m.ToTable("RegisteredTeamUsers").MapLeftKey("RegisteredUserId").MapRightKey("TeamId"));

            modelBuilder.Entity<Results>()
                .Property(e => e.ResultTime)
                .IsUnicode(false);

            modelBuilder.Entity<Results>()
                .Property(e => e.CalculatedResultTime)
                .IsUnicode(false);

            modelBuilder.Entity<SocialEvents>()
                .Property(e => e.SocialEventType)
                .IsUnicode(false);

            modelBuilder.Entity<SocialEvents>()
                .HasMany(e => e.RegisteredUserSocialEvents)
                .WithRequired(e => e.SocialEvents)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teams>()
                .HasMany(e => e.RaceEventTeams)
                .WithRequired(e => e.Teams)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teams>()
                .HasMany(e => e.Results)
                .WithRequired(e => e.Teams)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Entries)
                .WithRequired(e => e.Users)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.RegisteredUsers)
                .WithRequired(e => e.Users)
                .WillCascadeOnDelete(false);
        }
    }
}
