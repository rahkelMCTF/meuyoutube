using System;
using System.Collections.Generic;
using System.Text;
using meuyoutube.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace meuyoutube.Data
{
    public class ApplicationDbContext : IdentityDbContext<Usuario>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Video> Video { get; set; }
        public DbSet<Historico> Historico { get; set; }
        public DbSet<PlayList> PlayList { get; set; }
        public DbSet<VideoPlayList> VideoPlayList { get; set; }
        public DbSet<Visibilidade> Visibilidade { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<VideoPlayList>()
            .HasKey(v => new { v.IdPlayList, v.IdVideo });
        }
    }
}
