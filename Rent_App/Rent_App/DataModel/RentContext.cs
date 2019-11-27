namespace Rent_App.DataModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RentContext : DbContext
    {
        public RentContext()
            : base("name=RenContext")
        {
        }

        public virtual DbSet<CITY> CITies { get; set; }
        public virtual DbSet<PAVILION> PAVILIONs { get; set; }
        public virtual DbSet<RENT> RENTs { get; set; }
        public virtual DbSet<RENTER> RENTERs { get; set; }
        public virtual DbSet<ROLE> ROLEs { get; set; }
        public virtual DbSet<SHOP_CENTER> SHOP_CENTER { get; set; }
        public virtual DbSet<STAFF> STAFFs { get; set; }
        public virtual DbSet<STATUS_PAVILION> STATUS_PAVILION { get; set; }
        public virtual DbSet<STATUS_RENT> STATUS_RENT { get; set; }
        public virtual DbSet<STATUS_SC> STATUS_SC { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<V_SHOP_CENTER> V_SHOP_CENTER { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CITY>()
                .HasMany(e => e.SHOP_CENTER)
                .WithRequired(e => e.CITY)
                .HasForeignKey(e => e.City_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PAVILION>()
                .Property(e => e.Area)
                .HasPrecision(6, 2);

            modelBuilder.Entity<PAVILION>()
                .Property(e => e.Price_for_m)
                .HasPrecision(8, 2);

            modelBuilder.Entity<PAVILION>()
                .Property(e => e.Coff_advance_price)
                .HasPrecision(5, 2);

            modelBuilder.Entity<PAVILION>()
                .HasMany(e => e.RENTs)
                .WithOptional(e => e.PAVILION)
                .HasForeignKey(e => e.Pavilion_id);

            modelBuilder.Entity<RENTER>()
                .HasMany(e => e.RENTs)
                .WithRequired(e => e.RENTER)
                .HasForeignKey(e => e.Renter_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ROLE>()
                .HasMany(e => e.STAFFs)
                .WithRequired(e => e.ROLE)
                .HasForeignKey(e => e.Role_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SHOP_CENTER>()
                .Property(e => e.Price)
                .HasPrecision(12, 2);

            modelBuilder.Entity<SHOP_CENTER>()
                .HasMany(e => e.PAVILIONs)
                .WithRequired(e => e.SHOP_CENTER)
                .HasForeignKey(e => e.SC_name)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<STAFF>()
                .HasMany(e => e.RENTs)
                .WithRequired(e => e.STAFF)
                .HasForeignKey(e => e.Staff_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<STATUS_PAVILION>()
                .HasMany(e => e.PAVILIONs)
                .WithRequired(e => e.STATUS_PAVILION)
                .HasForeignKey(e => e.Status_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<STATUS_RENT>()
                .HasMany(e => e.RENTs)
                .WithRequired(e => e.STATUS_RENT)
                .HasForeignKey(e => e.Status_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<STATUS_SC>()
                .HasMany(e => e.SHOP_CENTER)
                .WithRequired(e => e.STATUS_SC)
                .HasForeignKey(e => e.Status_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<V_SHOP_CENTER>()
                .Property(e => e.Price)
                .HasPrecision(12, 2);
        }
    }
}
