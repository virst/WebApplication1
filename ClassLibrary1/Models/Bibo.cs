using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Models
{
    public class Bibo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Val1 { get; set; }
        public string Val2 { get; set; }
        public string Val3 { get; set; }
        public string Val4 { get; set; }
        public string Val5 { get; set; }
        public string Val6 { get; set; }

        public static List<Bibo> Bibos;

        static Bibo()
        {
            Random rnd = new();

            Bibos = new List<Bibo>();
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
        }

    }
}
