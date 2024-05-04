using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIEmployees.Models
{
    public partial class employeesContext : DbContext
    {
        public employeesContext()
        {
        }

        public employeesContext(DbContextOptions<employeesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AbsenceRequest> AbsenceRequests { get; set; } = null!;
        public virtual DbSet<AbsenceType> AbsenceTypes { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Gender> Genders { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<State> States { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AbsenceRequest>(entity =>
            {
                entity.ToTable("absenceRequest");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.AbsenceTypeId).HasColumnName("absenceTypeId");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("endDate");

                entity.Property(e => e.RequestDate)
                    .HasColumnType("date")
                    .HasColumnName("requestDate");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("startDate");

                entity.Property(e => e.StateId).HasColumnName("stateId");

                entity.HasOne(d => d.AbsenceType)
                    .WithMany(p => p.AbsenceRequests)
                    .HasForeignKey(d => d.AbsenceTypeId)
                    .HasConstraintName("fk_absenceTypeId");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.AbsenceRequests)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("fk_stateId");
            });

            modelBuilder.Entity<AbsenceType>(entity =>
            {
                entity.ToTable("absenceTypes");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Absence)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("absence");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.DateOfJoin)
                    .HasColumnType("date")
                    .HasColumnName("dateOfJoin");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstLastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("firstLastName");

                entity.Property(e => e.GenderId).HasColumnName("genderId");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");

                entity.Property(e => e.SecLastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("secLastName");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_genderId");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("gender");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.GenderV)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("gender");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Rolev)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("rolev");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("states");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.State1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("state");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.EmployeeId).HasColumnName("employeeId");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userName");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_employeeId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_roleId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
