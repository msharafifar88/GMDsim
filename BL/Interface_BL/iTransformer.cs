using network;
using persistent;
using System.Collections.Generic;

namespace BL
{
    public interface ITransformer
    {
        void create(MainTransformers transformer, Case cases);
        List<MainTransformers> loadAll(Case cases);
        void edit(MainTransformers transformer, Case cases);
        void remove(MainTransformers transformer, Case Cases);
        MainTransformers add(Case cases);
    }
}
