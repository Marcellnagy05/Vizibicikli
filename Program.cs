using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region tovabbi változatok
            //StreamReader sr = new StreamReader("DataSource\\kolcsonzesek.txt", true);
            //while (!sr.EndOfStream)
            //{
            //    var mezok = sr.ReadLine().Split(';');
            //    kolcsonzes uj = new kolcsonzes(
            //        mezok[0],
            //        mezok[1][0],
            //        int.Parse(mezok[2]),
            //        int.Parse(mezok[3]),
            //        int.Parse(mezok[4]),
            //        Convert.ToInt32(mezok[5]));
            //}
            //sr.Close();

            //linq + foreach

            //foreach (var sor in File.ReadAllLines("DataSource\\kolcsonzesek.txt"))
            //{
            //    kolcsonzesek.Add(new kolcsonzes(sor));
            //}
            #endregion

            //Linq
            List<kolcsonzes> kolcsonzesek = 
            File.ReadAllLines("DataSource\\kolcsonzesek.txt")
            .Skip(1)
            .Select(x => new kolcsonzes(x))
            .ToList();
            //5
            Console.WriteLine($"5.feladat: Napi kolcsonzések száma: {kolcsonzesek.Count()}");
            //6
            Console.WriteLine($"6.feladat: Kérek egy nevet:");
            string nev = Console.ReadLine();

            if(kolcsonzesek.Count(x => x.Nev == nev) == 0)
            {
                Console.WriteLine("Nem volt ilyen nevű köcsönző");
            }
            else
            {
                Console.WriteLine($"{nev}");
                foreach (var aktkolcsonzés in kolcsonzesek.Where(x => x.Nev == nev))
                {
                    Console.WriteLine($"{aktkolcsonzés.EOra}:{aktkolcsonzés.EPerc}-{aktkolcsonzés.VOra}:{aktkolcsonzés.VPerc}");
                }                     
            }

            kolcsonzesek.Where(x => x.Nev == nev).ToList().ForEach(x => Console.WriteLine($"{x.EOra}:{x.EPerc}-{x.VOra}:{x.VPerc}"));

            //7
            Console.WriteLine("7.Feladat");
            Console.WriteLine("Óra:");
            int ora = int.Parse(Console.ReadLine());
            Console.WriteLine("Perc:");
            int perc = int.Parse(Console.ReadLine());

            int ido = ora * 60 + perc;

            kolcsonzesek.Where(x => (x.VOra * 60 + x.VPerc) > ido && (x.EOra * 60 + x.EPerc) < ido)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.EOra}:{x.EPerc}-{x.VOra}:{x.VPerc} : {x.Nev}"));
            //var jarmuvek= kolcsonzesek.Where(x => x.EOra ) 

            //8
            int napibevetel = 2400 *  kolcsonzesek.Sum(x =>x.Idohossz()/30+1);
            Console.WriteLine($"8.feladat: napi bevétel: {napibevetel}");

            //9
            StreamWriter sw = new StreamWriter("F.txt");
            kolcsonzesek.Where(x => x.Jazon == 'F')
                .ToList()
                .ForEach(x => sw.WriteLine($"{x.EOra} : {x.EPerc} - {x.VOra}:{x.VPerc} : {x.Nev}"));
            sw.Close();

            //10
            

        }  
    }
}
