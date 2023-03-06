using DAO;
using display;
using network;
using persistent;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class Single3phaseLineBL : AbstractBL<Single3phaseLine>
    {
        Single3phaseLineDA single3phaseLineDA = new Single3phaseLineDA();
        public void create(Single3phaseLine single3phaseLine, Case cases)
        {
            single3phaseLineDA.Create(single3phaseLine, cases);
        }
        public List<Single3phaseLine> loadAll(Case cases)
        {

            return DataStored.findAllSingle3phaseLine(cases).ToList<Single3phaseLine>();
        }
        public void edit(Single3phaseLine single3phaseLine, Case cases)
        {
            single3phaseLineDA.Update(single3phaseLine, cases);
        }
        public void remove(Single3phaseLine single3phaseLine, Case Cases)
        {
            single3phaseLineDA.Delete(single3phaseLine, Cases);
        }

        public Single3phaseLine addLine(Case cases)
        {
            Single3phaseLine single3phaseLine = new Single3phaseLine();


            string name = single3phaseLine.Name;
            long code = single3phaseLine.Number;
            List<Single3phaseLine> single3phaseLines = loadAll(cases);
            if (single3phaseLines.Count() == 0)
            {
                name = name + " " + code;

            }
            else
            {
                foreach (Single3phaseLine b in single3phaseLines)
                {
                    if (b.Number >= code)
                    {
                        code = b.Number + 1;
                    }
                }
                name = name + " " + code;
            }

            single3phaseLine.Name = name;
            single3phaseLine.Number = code;
            ZoneBL zoneBL = new ZoneBL();
            Display display = new Display();
            //resistance.display = display;

            //if (zoneBL.loadAll().Count == 0)
            //{
            //    monoLine.zone = zoneBL.addZone();
            //}
            //else
            //{
            //    monoLine.zone = zoneBL.loadAll()[0];
            //}
            //AreaBL areaBL = new AreaBL();

            //if (areaBL.loadAll().Count == 0)
            //{
            //    monoLine.area = areaBL.addArea();
            //}
            //else
            //{
            //    monoLine.area = areaBL.loadAll()[0];
            //}

            create(single3phaseLine, cases);

            return single3phaseLine;
        }

        public override Single3phaseLine findByID(Case cases, long ID)
        {
            return single3phaseLineDA.findByID(cases, ID);
        }
    }
}
