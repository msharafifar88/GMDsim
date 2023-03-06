using network;
using persistent;
using System.Collections.Generic;

namespace BL
{
    public interface IRlcBL
    {
        void create(RLCbranches rlc, Case cases);
        List<RLCbranches> loadAll(Case cases);
        void edit(RLCbranches rlc, Case cases);
        void remove(RLCbranches rlc, Case Cases);
        RLCbranches add(Case cases);


    }
}
