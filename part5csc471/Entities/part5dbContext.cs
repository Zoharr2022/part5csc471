using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace part5csc471.Entities
{
    public partial class part5dbContext : DbContext
    {
        public part5dbContext()
        {
        }

        public part5dbContext(DbContextOptions<part5dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Allergy> Allergy { get; set; }
        public virtual DbSet<Billing> Billing { get; set; }
        public virtual DbSet<Insured> Insured { get; set; }
        public virtual DbSet<Lot> Lot { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Takes> Takes { get; set; }
        public virtual DbSet<Uninsured> Uninsured { get; set; }
        public virtual DbSet<VaccinationSite> VaccinationSite { get; set; }
        public virtual DbSet<Vaccine> Vaccine { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:part5csc471.database.windows.net,1433;Initial Catalog=part5db;Persist Security Info=False;User ID=part4csc471;Password=Zoie4121harris;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Allergy>(entity =>
            {
                entity.ToTable("allergy");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Allergyname)
                    .IsRequired()
                    .HasColumnName("allergyname")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Allergy)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__allergy__patient__0B91BA14");
            });

            modelBuilder.Entity<Billing>(entity =>
            {
                entity.ToTable("billing");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.SiteName)
                    .HasColumnName("site_name")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Billing)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__billing__patient__08B54D69");

                entity.HasOne(d => d.SiteNameNavigation)
                    .WithMany(p => p.Billing)
                    .HasForeignKey(d => d.SiteName)
                    .HasConstraintName("FK__billing__site_na__07C12930");
            });

            modelBuilder.Entity<Insured>(entity =>
            {
                entity.HasKey(e => e.PatientId)
                    .HasName("PK__insured__4D5CE4767996BF28");

                entity.ToTable("insured");

                entity.Property(e => e.PatientId)
                    .HasColumnName("patient_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CoPay).HasColumnName("co_pay");

                entity.Property(e => e.Company)
                    .HasColumnName("company")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Patient)
                    .WithOne(p => p.Insured)
                    .HasForeignKey<Insured>(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__insured__patient__0E6E26BF");
            });

            modelBuilder.Entity<Lot>(entity =>
            {
                entity.ToTable("lot");

                entity.HasIndex(e => e.Number)
                    .HasName("UQ__lot__FD291E41226985A5")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Expiration)
                    .HasColumnName("expiration")
                    .HasColumnType("date");

                entity.Property(e => e.MfrPlace)
                    .HasColumnName("mfr_place")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Number).HasColumnName("number");

                entity.Property(e => e.ScientName)
                    .HasColumnName("scient_name")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.ScientNameNavigation)
                    .WithMany(p => p.Lot)
                    .HasForeignKey(d => d.ScientName)
                    .HasConstraintName("FK__lot__scient_name__02084FDA");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("patient");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("date");

                entity.Property(e => e.FName)
                    .HasColumnName("f_name")
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LName)
                    .HasColumnName("l_name")
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MInitial)
                    .HasColumnName("m_initial")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Weight).HasColumnName("weight");
            });

            modelBuilder.Entity<Takes>(entity =>
            {
                entity.ToTable("takes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.ScientName)
                    .HasColumnName("scient_name")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SiteName)
                    .HasColumnName("site_name")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Takes)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__takes__patient_i__7C4F7684");

                entity.HasOne(d => d.ScientNameNavigation)
                    .WithMany(p => p.Takes)
                    .HasForeignKey(d => d.ScientName)
                    .HasConstraintName("FK__takes__scient_na__7D439ABD");

                entity.HasOne(d => d.SiteNameNavigation)
                    .WithMany(p => p.Takes)
                    .HasForeignKey(d => d.SiteName)
                    .HasConstraintName("FK__takes__site_name__7E37BEF6");
            });

            modelBuilder.Entity<Uninsured>(entity =>
            {
                entity.HasKey(e => e.PatientId)
                    .HasName("PK__uninsure__4D5CE476AFAA5E7D");

                entity.ToTable("uninsured");

                entity.Property(e => e.PatientId)
                    .HasColumnName("patient_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AddrCity)
                    .HasColumnName("addr_city")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddrState)
                    .HasColumnName("addr_state")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddrStreet)
                    .HasColumnName("addr_street")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddrZip)
                    .HasColumnName("addr_zip")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PmtMethod)
                    .HasColumnName("pmt_method")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Patient)
                    .WithOne(p => p.Uninsured)
                    .HasForeignKey<Uninsured>(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__uninsured__patie__04E4BC85");
            });

            modelBuilder.Entity<VaccinationSite>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK__vaccinat__72E12F1A596D60DC");

                entity.ToTable("vaccination_site");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddrCity)
                    .HasColumnName("addr_city")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddrState)
                    .HasColumnName("addr_state")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddrStreet)
                    .HasColumnName("addr_street")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddrZip)
                    .HasColumnName("addr_zip")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Vaccine>(entity =>
            {
                entity.HasKey(e => e.ScientName)
                    .HasName("PK__vaccine__417C9385A53207ED");

                entity.ToTable("vaccine");

                entity.Property(e => e.ScientName)
                    .HasColumnName("scient_name")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Dissease)
                    .HasColumnName("dissease")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NoDoses).HasColumnName("no_doses");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
