using Birlik.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Birlik.Data.Context
{
    public class BirlikDbContext : DbContext
    {
        public BirlikDbContext(){}
        public BirlikDbContext(DbContextOptions<BirlikDbContext> options): base(options){}
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<FileModel> Files { get; set; }
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseNpgsql("");
        // }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Teacher>().HasIndex(x=>x.UIN).IsUnique(true);
            builder.Entity<Teacher>()
            .HasOne(a => a.Resume)
            .WithOne(b => b.Teacher)
            .HasForeignKey<FileModel>(b => b.TeacherId);
        }
    }
}