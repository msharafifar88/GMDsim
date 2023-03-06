using System;

namespace fluxModel
{
    public class CurrentFlux
    {
        public double Current { get; set; }
        public double Flux { get; set; }

        public CurrentFlux(double current, double flux)
        {

            this.Current = current;
            this.Flux = flux;
        }
        public double this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0: return Current;
                    case 1: return Flux;
                    default: return Double.NaN;
                }
            }
        }
    }
}
