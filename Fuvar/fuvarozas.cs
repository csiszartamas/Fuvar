using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuvar
{
    internal class fuvarozas
    {
        public int taxiid { get; set; }
        public string indulasidopont { get; set; }
        public int utazasidotartam { get; set; }
        public double megtetttavolsag { get; set; }
        public double viteldij { get; set; }
        public double borravalo { get; set; }
        public string fizetesmodja { get; set; }

        public fuvarozas(string sor)
        {
            var v = sor.Split(';');
            this.taxiid = int.Parse(v[0]);
            this.indulasidopont = v[1];
            this.utazasidotartam = int.Parse(v[2]);
            this.megtetttavolsag = double.Parse(v[3]);
            this.viteldij = double.Parse(v[4]);
            this.borravalo = double.Parse(v[5]);
            this.fizetesmodja = v[6];
        }
    }
}
