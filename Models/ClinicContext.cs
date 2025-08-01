using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website1.Helpers;

namespace Website1.Models
{
    public class ClinicContext : IdentityDbContext<AppUser>
    {
        public ClinicContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Appointment>()
                                    .HasOne(p => p.Patient)
                                    .WithMany(a => a.Appointments)
                                    .HasForeignKey(p => p.PatientId);

            modelBuilder.Entity<Appointment>()
                                    .HasOne(d => d.Doctor)
                                    .WithMany(a => a.Appointments)
                                    .HasForeignKey(d => d.DoctorId);

            //modelBuilder.Entity<User_Role>()
            //                        .HasKey(ur => new { ur.UserId, ur.RoleId });  // composite key

            //modelBuilder.Entity<User_Role>()
            //                        .HasOne(ur => ur.User)                      // User_Role has one User
            //                        .WithMany(u => u.UserRoles)                 // User has many UserRoles
            //                        .HasForeignKey(ur => ur.UserId);

            //modelBuilder.Entity<User_Role>()
            //                        .HasOne(ur => ur.Roles)                      // User_Role has one Role
            //                        .WithMany(r => r.UserRoles)                 // Role has many UserRoles
            //.HasForeignKey(ur => ur.RoleId);

            modelBuilder.Entity<IdentityRole>().HasData(
                    new IdentityRole { Id = "217f57ab-5758-452d-b72d-830a7ddcf256", ConcurrencyStamp = "217f57ab-5758-452d-b72d-830a7ddcf256", Name = AppRoles.Admin.ToString(), NormalizedName = AppRoles.Admin.ToString().ToUpper() },
                    new IdentityRole { Id = "a3ac6f9e-6ea8-48da-b274-b49c2109a20d", ConcurrencyStamp = "a3ac6f9e-6ea8-48da-b274-b49c2109a20d", Name = AppRoles.Doctor.ToString(), NormalizedName = AppRoles.Doctor.ToString().ToUpper() },
                    new IdentityRole { Id = "faf40833-a58b-4b14-8ded-bb209099ce72", ConcurrencyStamp = "faf40833-a58b-4b14-8ded-bb209099ce72", Name = AppRoles.Receptionist.ToString(), NormalizedName = AppRoles.Receptionist.ToString().ToUpper() }
                );

            modelBuilder.Entity<Doctor>()
                .HasData(
                    new Doctor { Id = 1, FullName = "Hussam" }
                );

            modelBuilder.Entity<Patient>().HasData(
                new Patient
                {
                    Id = 1,
                    FullName = "Ahmed",
                    Email = "Hello@gmail.com",
                    PhoneNumber = "0123456789",
                    NationalId = "12345678901234",
                    DateOfBirth = new DateTime(1990, 1, 1)
                }
            );

            modelBuilder.Entity<Appointment>()
                .HasData(
                    new Appointment { Id = 1, AppointmentDate = new DateTime(2025, 8, 1, 17, 0, 0), DoctorId = 1, PatientId = 1, Status = "Pending" },
                    new Appointment { Id = 2, AppointmentDate = new DateTime(2025, 7, 25, 17, 0, 0), DoctorId = 1, PatientId = 1, Status = "Approved" },
                    new Appointment { Id = 3, AppointmentDate = new DateTime(2025, 8, 5, 17, 0, 0), DoctorId = 1, PatientId = 1, Status = "Rejected" }
                );
        }

    }
}


