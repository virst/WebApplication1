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



        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=" + Fn);

        public BiboContext()
        {
            Console.WriteLine("Data Source=" + Fn);
            InitRun = Database.EnsureCreated();
            if (!InitRun) return;

            Random rnd = new();

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

                Bibos.Add(b);
            }

            SaveChanges();
        }
    }
}
