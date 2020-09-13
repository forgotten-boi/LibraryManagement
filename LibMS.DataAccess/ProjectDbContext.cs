using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using LibMS.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace LibMS.DataAccess
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {

        }
        public DbSet<AssignBookInfo> AssignBookInfo { get; set; }
  
        public DbSet<BookCountInfo> BookCountInfo { get; set; }
        public DbSet<BookInfo> BookInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            builder.Entity<BookInfo>()
                 .HasOne(a => a.BookCountInfo).WithOne(b => b.BookInfo)
                .HasForeignKey<BookCountInfo>(e => e.BookID);

            builder.Entity<AssignBookInfo>()
                 .HasOne(e => e.BookInfo)
                 .WithMany(c => c.AssignBookInfoes).HasForeignKey(e => e.BookID);

            builder.Entity<AssignBookInfo>()
                 .HasOne(e => e.User)
                 .WithMany(c => c.AssignBookInfoes).HasForeignKey(e => e.UserID);


            base.OnModelCreating(builder);
       
        }
    }

   

    }

