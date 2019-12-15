using Microsoft.EntityFrameworkCore;
using SohailBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace SohailBookStore.Data
{
    public class SohailBookStoreDbContext:DbContext
    {
        public SohailBookStoreDbContext(DbContextOptions options):base(options)
        {
                
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Carousel> Carousels { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
