using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BUS.Models
{
    public partial class SprintRetrospectiveContext : DbContext
    {
        public SprintRetrospectiveContext()
        {
        }

        public SprintRetrospectiveContext(DbContextOptions<SprintRetrospectiveContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Board> Board { get; set; }
        public virtual DbSet<BoardDetail> BoardDetail { get; set; }
        public virtual DbSet<Column> Column { get; set; }
        public virtual DbSet<FacebookAccount> FacebookAccount { get; set; }
        public virtual DbSet<GoogleAccount> GoogleAccount { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-CMP87C0;Initial Catalog=SprintRetrospective;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BoardDetail>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Board)
                    .WithMany(p => p.BoardDetail)
                    .HasForeignKey(d => d.BoardId)
                    .HasConstraintName("FK_BoardDetail_Board");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.BoardDetail)
                    .HasForeignKey<BoardDetail>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BoardDetail_Column");
            });

            modelBuilder.Entity<FacebookAccount>(entity =>
            {
                entity.Property(e => e.Token).IsUnicode(false);
            });

            modelBuilder.Entity<GoogleAccount>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Token).IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.PassWord).IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserName).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
