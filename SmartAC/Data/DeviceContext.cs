using Microsoft.EntityFrameworkCore;
using SmartAC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAC.Data
{
    public class DeviceContext : DbContext
    {
        public DeviceContext(DbContextOptions<DeviceContext> options) : base(options)
        {
        }

        public DbSet<Device> Devices { get; set; }
        public DbSet<Sensor> Sensors { get; set; }

        public DbSet<DataReading> DataReadings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>().ToTable("Device");
            modelBuilder.Entity<Device>().Property(p => p.SerialNumber).HasMaxLength(50);
            modelBuilder.Entity<Device>().Property(p => p.FirmwareVersion).HasMaxLength(50);

            modelBuilder.Entity<Sensor>().ToTable("Sensor");

            modelBuilder.Entity<DataReading>().ToTable("DataReading");

            modelBuilder.Entity<DataReading>().Property(p => p.Status).HasMaxLength(150);
        }
    }
}
