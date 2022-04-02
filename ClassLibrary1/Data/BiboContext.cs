using ClassLibrary1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Data
{
    public class BiboContext : DbContext
    {

        public const string Fn = "bibos.db";

        public DbSet<Bibo> Bibos { get; set; }

        public bool InitRun { get; }

        public static string DbConn
        {
            get
            {
                var t = Environment.GetEnvironmentVariable("DB_CONN") ??
                    "Server=192.168.1.119;Port=5432;Database=bibo;User Id=user0;Password=12345;Command Timeout=100";
                //Console.WriteLine($"DbConn={t}");
                return t;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options
                .UseNpgsql(DbConn);
            if (FirstConfig)
                Console.WriteLine("DbConn={0}", DbConn);
            FirstRun = false;
        }

        private static bool FirstRun = true;
        private static bool FirstConfig = true;

        public BiboContext()
        {
            if (FirstRun)
                Database.Migrate();
            FirstRun = false;

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Random rnd = new(3);

            //Bibos = new List<Bibo>();
            for (int i = 0; i < 12456;)
            {
                Bibo b = new Bibo();
                b.Id = ++i;
                b.Name = "Bibo#" + i;

                b.Val1 = rnd.Next(1000, 10000).ToString();
                b.Val2 = rnd.Next(1000, 10000).ToString();
                b.Val3 = new string('#', rnd.Next(4, 10));
                b.Val4 = new string('G', rnd.Next(4, 10));
                b.Val5 = new string('R', rnd.Next(4, 10));
                b.Val6 = new string('8', rnd.Next(4, 10));

                //Bibos.Add(b);
                modelBuilder.Entity<Bibo>().HasData(b);
            }
        }       
    }
}
