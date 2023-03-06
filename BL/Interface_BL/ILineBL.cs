using network;
using persistent;
using System.Collections.Generic;


namespace BL
{
    public interface ILineBL
    {
        void create(LineBranches line, Case cases);
        List<LineBranches> loadAll(Case cases);
        void edit(LineBranches line, Case cases);
        void remove(LineBranches line, Case Cases);
        LineBranches addLine(Case cases);
        //
    }
}
