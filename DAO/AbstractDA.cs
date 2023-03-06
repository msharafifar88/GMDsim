using bases;
using persistent;
using System.Collections.Generic;

namespace DAO
{
    public abstract class AbstractDA<T>
    {
        void Create(T t) { }
        void Edit(T t) { }
        void Delete(T t) { }

        public long findLastId<T>(List<T> tl) where T : BaseEntity

        {
            long code = 1;
            if (tl.Count == 0)
            {
                return code;
            }
            else
            {
                foreach (T t in tl)
                {
                    if (t.ID >= code)
                    {
                        code = t.ID + 1;
                    }
                }
            }
            return code;
        }

        /*        public  T  findByID (Case cases, long ID ,List<T> tList )  
                {

                    foreach (T t in tList)
                    {


                        if (t.id == ID)
                        {
                            return t;
                        }
                    }
                    return null;
                }*/
        public void Add<T>(Case cases, T entity) where T : BaseEntity
        {

        }
        public void Edit<T>(Case cases, T entity) where T : BaseEntity
        {

        }
        public void Remove<T>(Case cases, T entity) where T : BaseEntity
        {

        }
    }
}
