using System.Collections.Generic;

namespace BL.Calculation_Core.ItemWraper
{
    public class vect_fit_DataWrapper
    {

        /*
           Fs  Start Frequency in Hz
           Fe  End Frequency in Hz
           Ns  Number of Frequency-points
           Nf  Order of the function
           Nl  Number of Layers
           Ro  Vector of layers resistivity
           Hi  Vector of layers hieghts
        */
        //public string bus_name { get; set; }
        public double Fs { get; set; }
        public double Fe { get; set; }
        public int Ns { get; set; }

        public int Nf { get; set; }

        public int Nl { get; set; } = 0;

        public List<double> Ro = new List<double>();

        public List<double> Hi = new List<double>();


        public override string ToString()
        {
            return "Vector fitting :" + Fs + " , " + Fe + " , " + Ns + " , " + Nf + " , " + Nl + " , " + Ro + " , " + Hi + " , ";
        }
    }
}
