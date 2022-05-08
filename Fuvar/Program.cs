using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuvar
{
    internal class Program
    {
        static List<fuvarozas> fuvar = new List<fuvarozas>();
        static List<string> hibas = new List<string>();
        static void Main(string[] args)
        {
           
            FileStream fs = new FileStream(@"..\..\res\fuvar.csv", FileMode.Open, FileAccess.Read, FileShare.None);
            StreamReader rs = new StreamReader(fs);
            rs.ReadLine();
            while (!rs.EndOfStream)
            {
                fuvar.Add(new fuvarozas(rs.ReadLine()));
            }
            rs.Close();
            Console.WriteLine("3. feladat" + fuvar.Count() +" fuvar");
            
            double bevetel = 0;
            int db = 0;
            int bankkartya = 0;
            int keszpenz = 0;
            int vitatott = 0;
            int ingyenes = 0;
            int ismeretlen = 0;
            double hossz = 0;
            int max = 0;
            int taxiazonosito = 0;
            double megtetttavolsag=0;
            double viteldij=0;
            foreach (var item in fuvar)
            {
                if(item.taxiid == 6185)
                {
                    bevetel += (item.borravalo + item.viteldij);
                    db++;
                }
                if(item.fizetesmodja == "bankkártya")
                {
                    bankkartya++;
                }
                if(item.fizetesmodja == "készpénz")
                {
                    keszpenz++;
                }
                if(item.fizetesmodja == "vitatott")
                {
                    vitatott++;
                }
                if(item.fizetesmodja == "ingyenes")
                {
                    ingyenes++;
                }
                if(item.fizetesmodja == "ismeretlen")
                {
                    ismeretlen++;
                }
                if(item.utazasidotartam > max)
                {
                    max = item.utazasidotartam;
                    taxiazonosito = item.taxiid;
                    megtetttavolsag = item.megtetttavolsag;
                    viteldij = item.viteldij;
                }
                if (item.viteldij > 0 && item.utazasidotartam > 0 && item.megtetttavolsag == 0)
                {
                    hibas.Add(item.taxiid + ";" + item.indulasidopont + ";" + item.utazasidotartam + ";" + item.megtetttavolsag + ";" + item.viteldij + ";" + item.borravalo + ";" + item.fizetesmodja);
                }
            }
            Console.WriteLine("4. feladat: "+db + "fuvar alatt: "+bevetel +"$");
            Console.WriteLine("5. feladat: \n\tbankkártya: " + bankkartya+" fuvar\n\tkészpénz: "+keszpenz+" fuvar\n\tvitatott: "+vitatott+" fuvar\n\tingyenes: "+ ingyenes + " fuvar\n\tismeretlen: "+ ismeretlen + " fuvar");
            Console.WriteLine("6. feladat: "+ Math.Round((hossz*1.6),2)+"km");
            Console.WriteLine("7. feladat: Leghosszabb fuvar: \n\t Fuvar hossza: " + max + "másodperc\n\tTaxi azonosító: " + taxiazonosito + "\n\tMegtett távolság: " + Math.Round(megtetttavolsag, 1) + "\n\tViteldíj: " + viteldij + "$");
            fuvar = fuvar.OrderBy(i => i.indulasidopont).ToList();
            
            StreamWriter sw = new StreamWriter(@"..\..\res\hibak.txt", false);
            sw.WriteLine("taxi_id;indulas;idotartam;tavolsag;viteldij;borravalo;fizetes_modja");
            for (int i = 0; i < hibas.Count; i++)
            {
                sw.WriteLine("{0};", hibas[i].ToString());
            }
            sw.Close();
            Console.WriteLine("8. feladat: hibak.txt legenerálva!");
            Console.ReadKey();
        }
    }
}
