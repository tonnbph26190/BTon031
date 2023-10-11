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
        public DbSet<PC> PCs { get; set; }
        public DbSet<PcDetail> PcDetails { get; set; }
        public DbSet<Custom> Customs { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<Power> Powers { get; set; }
        public DbSet<Cooling> Coolings { get; set; }
        public DbSet<MonitorDetail> MONITORDETAILS { get; set; }
        public DbSet<Panel> Panels { get; set; }
        public DbSet<Resolution> Resolutions { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail  { get; set; }
        public DbSet<OrderDetailLaptopDetail> OrderDetailLaptopDetails { get; set; }
        public DbSet<OrderLaptop> OrderLaptops { get; set; }
        public DbSet<OrderMonitor> OrderMonitors  { get; set; }
        public DbSet<OrderMonitorDetail> OrderMonitorDetails  { get; set; }
        public DbSet<DATA.Entity.Monitor> Monitors { get; set; }
    }
}
