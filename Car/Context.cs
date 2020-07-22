using Car.Entity;
using Microsoft.EntityFrameworkCore;

namespace Car
{
    public class Context:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Body> Bodies { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public Context(DbContextOptions<Context> dbContext) : base(dbContext)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Comment>().HasOne<User>().WithMany().HasForeignKey(x => x.UserId);
            mb.Entity<Comment>().HasOne<Machine>().WithMany(x => x.Comments).HasForeignKey(y => y.MachineId);
            mb.Entity<Machine>().HasOne<Brand>().WithMany().HasForeignKey(x => x.BrandId);
            mb.Entity<Machine>().HasOne<Body>().WithMany().HasForeignKey(x => x.BodyId);
        }
    }
}
