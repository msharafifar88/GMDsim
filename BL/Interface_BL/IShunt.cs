using network;
using persistent;
using System.Collections.Generic;

namespace BL
{
    public interface IShunt
    {
        void create(SwitchBranches shunt, Case cases);
        List<SwitchBranches> loadAll(Case cases);
        void edit(SwitchBranches shunt, Case cases);
        void remove(SwitchBranches shunt, Case Cases);
        SwitchBranches add(Case cases);
    }
}
