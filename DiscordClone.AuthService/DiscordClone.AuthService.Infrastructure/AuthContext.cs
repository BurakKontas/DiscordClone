using System;
using System.Collections.Generic;
using DiscordClone.AuthService.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscordClone.AuthService.Infrastructure;

public partial class AuthContext : DbContext
{
    public AuthContext()
    {
    }

    public AuthContext(DbContextOptions<AuthContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Auth> Auths { get; set; }

    public virtual DbSet<Ban> Bans { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Auth>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("auth_pkey");

            entity.ToTable("auth");

            entity.HasIndex(e => e.Email, "auth_email_key").IsUnique();

            entity.HasIndex(e => e.Useruuid, "auth_useruuid_key").IsUnique();

            entity.HasIndex(e => e.Useruuid, "idx_auth_useruuid");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Banned)
                .HasDefaultValue(false)
                .HasColumnName("banned");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.EmailVerified)
                .HasDefaultValue(false)
                .HasColumnName("email_verified");
            entity.Property(e => e.LastLogin)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_login");
            entity.Property(e => e.Passwordhash)
                .HasMaxLength(255)
                .HasColumnName("passwordhash");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Useruuid).HasColumnName("useruuid");

            entity.HasOne(d => d.Role).WithMany(p => p.Auths)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("auth_role_id_fkey");
        });

        modelBuilder.Entity<Ban>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("bans_pkey");

            entity.ToTable("bans");

            entity.HasIndex(e => e.Useruuid, "idx_bans_useruuid");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Adminuuid).HasColumnName("adminuuid");
            entity.Property(e => e.BanDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ban_date");
            entity.Property(e => e.BanReason).HasColumnName("ban_reason");
            entity.Property(e => e.Useruuid).HasColumnName("useruuid");

            entity.HasOne(d => d.User).WithMany(p => p.Bans)
                .HasPrincipalKey(p => p.Useruuid)
                .HasForeignKey(d => d.Useruuid)
                .HasConstraintName("fk_bans_useruuid");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.HasIndex(e => e.RoleName, "roles_role_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasColumnName("role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
