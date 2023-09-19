using DATA.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Context
{
    public class LapDbContext: DbContext
    {
        public LapDbContext()
        {

        }

        public LapDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Thực hiện các ràng buộc kết nối
            base.OnConfiguring(optionsBuilder.
               UseOracle(@"User Id=SYSTEM;Password=Ton2003;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST =localhost)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=ORCL)))"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
        public DbSet<Battery> Batteries { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Laptop_Detail> laptop_Details { get; set; }
        public DbSet<Main> Mains { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Ram> Rams { get; set; }
        public DbSet<Screen> Screens { get; set; }
        public DbSet<SSD> SSDs { get; set; }
        public DbSet<VGA> VGAs { get; set; }
        public DbSet<Webcam> Webcams { get; set; }
    }
}
