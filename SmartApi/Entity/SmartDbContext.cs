using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Web;
using Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartApi.Entity
{
    public class SmartDbContext : DbContext
    {
        public SmartDbContext(string connectionName)
            : base(connectionName ?? "SmartHome")
        {
            
        }

        public DbSet<HOMELIST> HomeLists { get; set; }
        public DbSet<ROOMLIST> RoomLists { get; set; }
        public DbSet<BLOK> Bloks { get; set; }
        public DbSet<HOME> Homes { get; set; }
        public DbSet<HOMEDEVICETYPE> HomeDeviceTypes { get; set; }
        public DbSet<LOG> Logs { get; set; }
        public DbSet<ROOM> Rooms { get; set; }
        public DbSet<ROOMDEVICEVALUE> RoomDeviceValues { get; set; }
        public DbSet<USER> Users { get; set; }
        public DbSet<ADMIN> Admins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<BLOK>()
                .Property(a => a.LREF).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<HOME>()
                .Property(a => a.LREF).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<HOMEDEVICETYPE>()
                .Property(a => a.LREF).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<LOG>()
                .Property(a => a.LREF).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<ROOM>()
                .Property(a => a.LREF).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<ROOMDEVICEVALUE>()
                .Property(a => a.LREF).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<USER>()
                .Property(a => a.LREF).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<HOMELIST>()
                .Property(a => a.LREF).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<ROOMLIST>()
                .Property(a => a.LREF).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<ADMIN>()
                .Property(a => a.LREF).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}