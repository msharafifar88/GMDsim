using persistent;

namespace BL
{
    public abstract class AbstractBL<T>
    {
        public abstract T findByID(Case cases, long ID);

    }
}
