using BL.Calculation_Core.ItemWraper;
using System.Collections.Generic;

namespace BL.Calculation_Core.Calculation_Class
{
    public class BusType
    {
        List<BusDataWrapper> busDataWrappers;

        public BusType(List<BusDataWrapper> busDataWrappers)
        {
            this.busDataWrappers = busDataWrappers;
        }

        public (List<BusDataWrapper>, List<BusDataWrapper>, List<BusDataWrapper>) findBusBytype()
        {
            List<BusDataWrapper> bus_ref = new List<BusDataWrapper>();
            List<BusDataWrapper> pv = new List<BusDataWrapper>();
            List<BusDataWrapper> pq = new List<BusDataWrapper>();
            busDataWrappers.ForEach(delegate (BusDataWrapper b)
          {
              if (b.bus_type.Equals(3))
              {
                  bus_ref.Add(b);

              }
              else if (b.bus_type.Equals(2))
              {
                  pv.Add(b);

              }
              else if (b.bus_type.Equals(1))
              {
                  pq.Add(b);
              }
          });


            return (bus_ref, pv, pq);

        }
    }
}
