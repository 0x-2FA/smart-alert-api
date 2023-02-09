using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace smart_alert_api.Models.Database
{
    public partial class SmartAlertContext : IdentityDbContext<EntityUser>
    {
        public SmartAlertContext()
        {
        }

        public SmartAlertContext(DbContextOptions<SmartAlertContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Event> Events { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_Events_user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.Photo).HasColumnName("photo");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.Timestamp).HasColumnName("timestamp");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.UserId).HasColumnName("user_id");
                
                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId);
            });

            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
