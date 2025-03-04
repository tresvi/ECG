using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECGViewer.Models
{
    internal class ECG
    {
        public double TMuestreo { get; set; }
        public double FMuestreo { get 
            {
                if (this.TMuestreo == 0) return 0;
                return 1 / TMuestreo;
            }
        }

        public double[] Channel0 { get; set; }
        public double[] Channel1 { get; set; }
        public double[] Channel2 { get; set; }
        public double[] Channel3 { get; set; }
        public double[] Channel4 { get; set; }
        public double[] Channel5 { get; set; }
        public double[] Channel6 { get; set; }
        public double[] Channel8 { get; set; }
        public double[] Channel9 { get; set; }
        public double[] Channel10 { get; set; }
        public double[] Channel11 { get; set; }
    }
}
