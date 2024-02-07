using Microsoft.EntityFrameworkCore;
using ZawHtutTest.Models;

namespace ZawHtutTest.Database
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options ) : base(options)
        {
                
        }

        public virtual DbSet<Student> Students { get; set; }
    }
}
