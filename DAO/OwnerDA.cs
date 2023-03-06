using areaandzone;
using System.Collections.Generic;
using System.Linq;

namespace DAO
{
    public class OwnerDA
    {
        public void Create(Owner owner)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.Owners.Add(owner);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.addOwner(owner);
            }
        }

        public void Update(Owner owner)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.Owners.Add(owner);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.addOwner(owner);

            }

        }

        public void Delete(Owner owner)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.Owners.Remove(owner);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.removeOwner(owner);
            }

        }
        public List<Owner> loadAll()
        {
            return DataStored.findAllOwner().ToList();
        }
    }
}
