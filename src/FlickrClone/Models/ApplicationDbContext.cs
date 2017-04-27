using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FlickrClone.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ImagesApplicationUsers>()
                 .HasKey(t => new { t.ImageId, t.ApplicationUserId });

            builder.Entity<ImagesApplicationUsers>()
                .HasOne(pt => pt.Image)
                .WithMany(p => p.ImagesApplicationUsers)
                .HasForeignKey(pt => pt.ImageId);

            builder.Entity<ImagesApplicationUsers>()
               .HasOne(pt => pt.TaggedUser)
               .WithMany(p => p.ImagesApplicationUsers)
               .HasForeignKey(pt => pt.ApplicationUserId);
            base.OnModelCreating(builder);
        }
        public DbSet<Image> Images { get; set; }

        // New stuff
        //public virtual DbSet<TaggedUsers> Users { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=FlickrClone;integrated security=True;");
        //}
        //ending
    }
}
