using DAO;
using persistent;
using System;
using System.Collections.Generic;
using System.Linq;
namespace BL
{
    public class CaseBL : AbstractBL<Case>
    {
        CaseDA caseDA = new CaseDA();

        public void createCase(Case cases)
        {
            caseDA.Create(cases);
        }
        public List<Case> loadAll()
        {
            return caseDA.loadAll();
        }
        public void editCase(Case cases)
        {
            caseDA.Update(cases);
        }
        public void removeCase(Case cases)
        {
            caseDA.Delete(cases);
        }
        public void removeAllCase()
        {
            caseDA.removeAll();
        }
        public Case findCaseByName(string name)
        {
            return caseDA.findByName(name);
        }

        public Case addCase()
        {
            Case cases = new Case();


            string name = "Case";
            long code = 1;
            List<Case> caseList = loadAll();
            if (caseList.Count() == 0)
            {
                name = name + " " + code;

            }
            else
            {
                foreach (Case b in caseList)
                {
                    if (b.code >= code)
                    {
                        code = b.code + 1;
                    }
                }
                name = name + " " + code;
            }

            cases.name = name;
            cases.code = code;

            createCase(cases);


            return cases;
        }

        public override Case findByID(Case cases, long ID)
        {
            throw new NotImplementedException();
        }
    }
}
