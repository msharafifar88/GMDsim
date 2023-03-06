using DAO;
using display;
using network;
using persistent;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class DoubleCircuitLineBL : AbstractBL<DoubleCircuitLine>
    {
        DoubleCircuitLineDA doubleCircuitLineLineDA = new DoubleCircuitLineDA();
        public void create(DoubleCircuitLine DobCir, Case cases)
        {

            doubleCircuitLineLineDA.Create((DoubleCircuitLine)DobCir, cases);

        }
        public List<DoubleCircuitLine> loadAll(Case cases)
        {
            return DataStored.findAllDoubleCircuitLine(cases).ToList<DoubleCircuitLine>();
        }
        public void edit(DoubleCircuitLine DobCir, Case cases)
        {

            doubleCircuitLineLineDA.Update((DoubleCircuitLine)DobCir, cases);

        }
        public void remove(DoubleCircuitLine DobCir, Case Cases)
        {

            doubleCircuitLineLineDA.Delete((DoubleCircuitLine)DobCir, Cases);

        }

        public DoubleCircuitLine addLine(Case cases)
        {
            DoubleCircuitLine DobCir = new DoubleCircuitLine();


            string name = DobCir.Name;
            long code = DobCir.Number;
            List<DoubleCircuitLine> DobCirs = loadAll(cases);
            if (DobCirs.Count() == 0)
            {
                name = name + " " + code;

            }
            else
            {
                foreach (DoubleCircuitLine b in DobCirs)
                {
                    if (b.Number >= code)
                    {
                        code = b.Number + 1;
                    }
                }
                name = name + " " + code;
            }

            DobCir.Name = name;
            DobCir.Number = code;
            ZoneBL zoneBL = new ZoneBL();
            Display display = new Display();
            //resistance.display = display;

            //if (zoneBL.loadAll().Count == 0)
            //{
            //    biLine.zone = zoneBL.addZone();
            //}
            //else
            //{
            //    biLine.zone = zoneBL.loadAll()[0];
            //}
            //AreaBL areaBL = new AreaBL();

            //if (areaBL.loadAll().Count == 0)
            //{
            //    biLine.area = areaBL.addArea();
            //}
            //else
            //{
            //    biLine.area = areaBL.loadAll()[0];
            //}

            create(DobCir, cases);

            return DobCir;
        }

        public override DoubleCircuitLine findByID(Case cases, long ID)
        {
            return doubleCircuitLineLineDA.findByID(cases, ID);
        }
    }
}
