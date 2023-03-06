using persistent;
using System.Collections.Generic;
using System.Linq;

namespace DAO
{
    public class CaseDA
    {
        public void Create(Case cases)
        {

            DataStored.addCase(cases);

        }

        public void Update(Case cases)
        {

            DataStored.addCase(cases);


        }

        public void Delete(Case cases)
        {

            DataStored.removeCase(cases);


        }
        public List<Case> loadAll()
        {
            return DataStored.findAllCase().ToList();
        }

        public void removeAll()
        {
            DataStored.removeAllCase();
        }

        public Case findByName(string name)
        {
            return DataStored.findCase(name);
        }
    }
}
