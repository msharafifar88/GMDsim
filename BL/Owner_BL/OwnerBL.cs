using areaandzone;
using DAO;
using persistent;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class OwnerBL : AbstractBL<Owner>
    {
        OwnerDA ownerDA = new OwnerDA();

        public void createOwner(Owner owner)
        {
            ownerDA.Create(owner);
        }
        public List<Owner> loadAll()
        {
            return ownerDA.loadAll();
        }
        public void editOwner(Owner owner)
        {
            ownerDA.Update(owner);
        }
        public void removeOwner(Owner owner)
        {
            ownerDA.Delete(owner);
        }

        public Owner addOwner()
        {
            Owner owner = new Owner();
            string name = "Owner";
            long code = 1;
            List<Owner> owners = loadAll();
            if (owners.Count() == 0)
            {
                name = name + " " + code;

            }
            else
            {
                foreach (Owner o in owners)
                {
                    if (o.Number >= code)
                    {
                        code = o.Number + 1;
                    }
                }
                name = name + " " + code;
            }

            owner.Name = name;
            owner.Number = code;

            createOwner(owner);

            return owner;
        }

        public override Owner findByID(Case cases, long ID)
        {
            throw new NotImplementedException();
        }
    }
}
