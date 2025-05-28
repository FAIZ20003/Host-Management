using System;
using System.Collections.Generic;
using AssetManager.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetManager.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Hostdetail> Hostdetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=206.189.140.214;Database=ITINFRA_MOWS2025;User Id=sa;Password=dbadmin@2025;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hostdetail>(entity =>
        {
            entity.HasKey(e => e.DeviceId).HasName("PK__HOSTDETA__860317839573B977");

            entity.ToTable("HOSTDETAILS");

            entity.Property(e => e.DeviceId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DEVICE_ID");
            entity.Property(e => e.HostGroup)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("HOST_GROUP");
            entity.Property(e => e.HostName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("HOST_NAME");
            entity.Property(e => e.HostStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("HOST_STATUS");
            entity.Property(e => e.HostUser)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("HOST_USER");
            entity.Property(e => e.IpAddress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("IP_ADDRESS");
            entity.Property(e => e.MacAddress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MAC_ADDRESS");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
