﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Web.Entities.DataTransferObjects.DashboardDTOs;

namespace Web.Entities.Models
{
    public partial class Dat502Ass2DBContext : DbContext
    {
        public Dat502Ass2DBContext()
        {
        }

        public Dat502Ass2DBContext(DbContextOptions<Dat502Ass2DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAddress> TblAddress { get; set; }
        public virtual DbSet<TblAdvert> TblAdvert { get; set; }
        public virtual DbSet<TblBranch> TblBranch { get; set; }
        public virtual DbSet<TblClient> TblClient { get; set; }
        public virtual DbSet<TblGender> TblGender { get; set; }
        public virtual DbSet<TblLease> TblLease { get; set; }
        public virtual DbSet<TblLeaseType> TblLeaseType { get; set; }
        public virtual DbSet<TblOwner> TblOwner { get; set; }
        public virtual DbSet<TblOwnerType> TblOwnerType { get; set; }
        public virtual DbSet<TblPaymentMethod> TblPaymentMethod { get; set; }
        public virtual DbSet<TblProperty> TblProperty { get; set; }
        public virtual DbSet<TblPropertyType> TblPropertyType { get; set; }
        public virtual DbSet<TblRegistration> TblRegistration { get; set; }
        public virtual DbSet<TblStaff> TblStaff { get; set; }
        public virtual DbSet<TblSystemUser> TblSystemUser { get; set; }
        public virtual DbSet<TblSystemUserType> TblSystemUserType { get; set; }
        public virtual DbSet<TblViewing> TblViewing { get; set; }

        public virtual DbQuery<ClientDashboardDTO> ClientDashboard { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<TblAddress>(entity =>
            {
                entity.HasKey(e => e.AddressNo)
                    .HasName("PK_Address");

                entity.ToTable("tbl_Address");

                entity.Property(e => e.CityOrTownName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PostCode)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.StreetNumber)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.StreetOrRoadName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblAdvert>(entity =>
            {
                entity.HasKey(e => e.AdvertNo)
                    .HasName("PK_Advert");

                entity.ToTable("tbl_Advert");

                entity.Property(e => e.DateAdvertised).HasColumnType("datetime");

                entity.Property(e => e.NewsPaperName)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.HasOne(d => d.PropertyNoNavigation)
                    .WithMany(p => p.TblAdvert)
                    .HasForeignKey(d => d.PropertyNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Adver__Prope__4F7CD00D");
            });

            modelBuilder.Entity<TblBranch>(entity =>
            {
                entity.HasKey(e => e.BranchNo)
                    .HasName("PK_Branch");

                entity.ToTable("tbl_Branch");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.AddressNoNavigation)
                    .WithMany(p => p.TblBranch)
                    .HasForeignKey(d => d.AddressNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Branc__Addre__31EC6D26");
            });

            modelBuilder.Entity<TblClient>(entity =>
            {
                entity.HasKey(e => e.ClientNo)
                    .HasName("PK_Client");

                entity.ToTable("tbl_Client");

                entity.Property(e => e.PreferredAccomodationType)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.SystemUserNoNavigation)
                    .WithMany(p => p.TblClient)
                    .HasForeignKey(d => d.SystemUserNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Clien__Syste__3D5E1FD2");
            });

            modelBuilder.Entity<TblGender>(entity =>
            {
                entity.HasKey(e => e.GenderNo)
                    .HasName("PK__tbl_Gend__4E264A20F2ED68B5");

                entity.ToTable("tbl_Gender");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLease>(entity =>
            {
                entity.HasKey(e => e.LeaseNo)
                    .HasName("PK_Lease");

                entity.ToTable("tbl_Lease");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.ClientNoNavigation)
                    .WithMany(p => p.TblLease)
                    .HasForeignKey(d => d.ClientNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Lease__Clien__534D60F1");

                entity.HasOne(d => d.LeaseTypeNoNavigation)
                    .WithMany(p => p.TblLease)
                    .HasForeignKey(d => d.LeaseTypeNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Lease__Lease__5441852A");

                entity.HasOne(d => d.PaymentMethodNoNavigation)
                    .WithMany(p => p.TblLease)
                    .HasForeignKey(d => d.PaymentMethodNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Lease__Payme__5535A963");

                entity.HasOne(d => d.PropertyNoNavigation)
                    .WithMany(p => p.TblLease)
                    .HasForeignKey(d => d.PropertyNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Lease__Prope__52593CB8");
            });

            modelBuilder.Entity<TblLeaseType>(entity =>
            {
                entity.HasKey(e => e.LeaseTypeNo)
                    .HasName("PK__tbl_Leas__F4D24D5E152D99F1");

                entity.ToTable("tbl_LeaseType");

                entity.Property(e => e.LeaseTypeDesc)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblOwner>(entity =>
            {
                entity.HasKey(e => e.OwnerNo)
                    .HasName("PK_Owner");

                entity.ToTable("tbl_Owner");

                entity.HasOne(d => d.OwnerTypeNoNavigation)
                    .WithMany(p => p.TblOwner)
                    .HasForeignKey(d => d.OwnerTypeNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Owner__Owner__44FF419A");

                entity.HasOne(d => d.SystemUserNoNavigation)
                    .WithMany(p => p.TblOwner)
                    .HasForeignKey(d => d.SystemUserNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Owner__Syste__45F365D3");
            });

            modelBuilder.Entity<TblOwnerType>(entity =>
            {
                entity.HasKey(e => e.OwnerTypeNo)
                    .HasName("PK__tbl_Owne__CA4B541A844E2069");

                entity.ToTable("tbl_OwnerType");

                entity.Property(e => e.OwnerType)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerTypeDesc)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPaymentMethod>(entity =>
            {
                entity.HasKey(e => e.PaymentMethodNo)
                    .HasName("PK__tbl_Paym__DC326B798D2CED46");

                entity.ToTable("tbl_PaymentMethod");

                entity.Property(e => e.PaymentMethod)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentMethodDesc)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblProperty>(entity =>
            {
                entity.HasKey(e => e.PropertyNo)
                    .HasName("PK_Property");

                entity.ToTable("tbl_Property");

                entity.HasOne(d => d.AddressNoNavigation)
                    .WithMany(p => p.TblProperty)
                    .HasForeignKey(d => d.AddressNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Prope__Addre__4AB81AF0");

                entity.HasOne(d => d.BranchNoNavigation)
                    .WithMany(p => p.TblProperty)
                    .HasForeignKey(d => d.BranchNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Prope__Branc__49C3F6B7");

                entity.HasOne(d => d.OwnerNoNavigation)
                    .WithMany(p => p.TblProperty)
                    .HasForeignKey(d => d.OwnerNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Prope__Owner__48CFD27E");

                entity.HasOne(d => d.PropertyTypeNoNavigation)
                    .WithMany(p => p.TblProperty)
                    .HasForeignKey(d => d.PropertyTypeNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Prope__Prope__4BAC3F29");

                entity.HasOne(d => d.StaffNoNavigation)
                    .WithMany(p => p.TblProperty)
                    .HasForeignKey(d => d.StaffNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Prope__Staff__4CA06362");
            });

            modelBuilder.Entity<TblPropertyType>(entity =>
            {
                entity.HasKey(e => e.PropertyTypeNo)
                    .HasName("PK__tbl_Prop__BDE174D704690285");

                entity.ToTable("tbl_PropertyType");

                entity.Property(e => e.PropertyType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyTypeDesc)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblRegistration>(entity =>
            {
                entity.HasKey(e => e.RegistrationNo)
                    .HasName("PK_Registration");

                entity.ToTable("tbl_Registration");

                entity.Property(e => e.DateJoined).HasColumnType("date");

                entity.HasOne(d => d.BranchNoNavigation)
                    .WithMany(p => p.TblRegistration)
                    .HasForeignKey(d => d.BranchNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Regis__Branc__412EB0B6");

                entity.HasOne(d => d.ClientNoNavigation)
                    .WithMany(p => p.TblRegistration)
                    .HasForeignKey(d => d.ClientNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Regis__Clien__4222D4EF");

                entity.HasOne(d => d.StaffNoNavigation)
                    .WithMany(p => p.TblRegistration)
                    .HasForeignKey(d => d.StaffNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Regis__Staff__403A8C7D");
            });

            modelBuilder.Entity<TblStaff>(entity =>
            {
                entity.HasKey(e => e.StaffNo)
                    .HasName("PK_Staff");

                entity.ToTable("tbl_Staff");

                entity.HasOne(d => d.BranchNoNavigation)
                    .WithMany(p => p.TblStaff)
                    .HasForeignKey(d => d.BranchNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Staff__Branc__38996AB5");

                entity.HasOne(d => d.GenderNoNavigation)
                    .WithMany(p => p.TblStaff)
                    .HasForeignKey(d => d.GenderNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Staff__Gende__3A81B327");

                entity.HasOne(d => d.SystemUserNoNavigation)
                    .WithMany(p => p.TblStaff)
                    .HasForeignKey(d => d.SystemUserNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Staff__Syste__398D8EEE");
            });

            modelBuilder.Entity<TblSystemUser>(entity =>
            {
                entity.HasKey(e => e.SystemUserNo)
                    .HasName("PK_SystemUser");

                entity.ToTable("tbl_SystemUser");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.AddressNoNavigation)
                    .WithMany(p => p.TblSystemUser)
                    .HasForeignKey(d => d.AddressNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Syste__Addre__35BCFE0A");

                entity.HasOne(d => d.SystemUserTypeNoNavigation)
                    .WithMany(p => p.TblSystemUser)
                    .HasForeignKey(d => d.SystemUserTypeNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Syste__Syste__34C8D9D1");
            });

            modelBuilder.Entity<TblSystemUserType>(entity =>
            {
                entity.HasKey(e => e.SystemUserTypeNo)
                    .HasName("PK__tbl_Syst__73D7BBFD81BD526B");

                entity.ToTable("tbl_SystemUserType");

                entity.Property(e => e.SystemUserType)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.SystemUserTypeDesc)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblViewing>(entity =>
            {
                entity.HasKey(e => e.ViewingNo)
                    .HasName("PK_Viewing");

                entity.ToTable("tbl_Viewing");

                entity.Property(e => e.ClientComment)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DateViewed).HasColumnType("date");

                entity.HasOne(d => d.ClientNoNavigation)
                    .WithMany(p => p.TblViewing)
                    .HasForeignKey(d => d.ClientNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Viewi__Clien__59063A47");

                entity.HasOne(d => d.PropertyNoNavigation)
                    .WithMany(p => p.TblViewing)
                    .HasForeignKey(d => d.PropertyNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Viewi__Prope__5812160E");
            });
        }
    }
}
