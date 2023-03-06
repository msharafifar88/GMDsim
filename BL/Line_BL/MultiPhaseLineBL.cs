using DAO;
using display;
using network;
using persistent;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class MultiPhaseLineBL : AbstractBL<MultiPhaseLine>
    {
        MultiPhaseLineDA multiLineDA = new MultiPhaseLineDA();
        public void create(MultiPhaseLine multiLine, Case cases)
        {
            multiLineDA.Create(multiLine, cases);
        }
        public List<MultiPhaseLine> loadAll(Case cases)
        {

            return DataStored.findAllMultiPhaseLine(cases).ToList<MultiPhaseLine>();
        }
        public void edit(MultiPhaseLine multiLine, Case cases)
        {
            multiLineDA.Update(multiLine, cases);
        }
        public void remove(MultiPhaseLine multiLine, Case cases)
        {
            multiLineDA.Delete(multiLine, cases);
        }

        public MultiPhaseLine addLine(Case cases)
        {
            MultiPhaseLine multiLine = new MultiPhaseLine();


            string name = multiLine.Name;
            long code = multiLine.Number;
            List<MultiPhaseLine> multiLines = loadAll(cases);
            if (multiLines.Count() == 0)
            {
                name = name + " " + code;

            }
            else
            {
                foreach (MultiPhaseLine b in multiLines)
                {
                    if (b.Number >= code)
                    {
                        code = b.Number + 1;
                    }
                }
                name = name + " " + code;
            }

            multiLine.Name = name;
            multiLine.Number = code;
            ZoneBL zoneBL = new ZoneBL();
            Display display = new Display();
            //resistance.display = display;

            //if (zoneBL.loadAll().Count == 0)
            //{
            //    triLine.zone = zoneBL.addZone();
            //}
            //else
            //{
            //    triLine.zone = zoneBL.loadAll()[0];
            //}
            //AreaBL areaBL = new AreaBL();

            //if (areaBL.loadAll().Count == 0)
            //{
            //    triLine.area = areaBL.addArea();
            //}
            //else
            //{
            //    triLine.area = areaBL.loadAll()[0];
            //}

            create(multiLine, cases);

            return multiLine;
        }

        public override MultiPhaseLine findByID(Case cases, long ID)
        {
            return multiLineDA.findByID(cases, ID);
        }
    }
}
