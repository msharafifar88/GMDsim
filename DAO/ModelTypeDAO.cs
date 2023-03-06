using bases;
using System;
using System.Collections.Generic;

namespace DAO
{
    public class ModelTypeDAO
    {
        public List<ModelType> findAll()
        {

            List<String> child = new List<String> { "Generators", "Bus", "Load", "Transformers", };

            long l = 1;
            List<ModelType> modelTypes = new List<ModelType>();
            foreach (String name in child)
            {
                ModelType modelType = new ModelType();
                modelType.name = name;
                modelType.code = l + 1;
                modelTypes.Add(modelType);
            }

            return modelTypes;
        }
        /* public void creatTree()
         {




             foreach (String name in root)
             {

                 foreach(var child in MapChild)
                 {
                     if (child.Key.Equals(name))
                     {


                     }
                 }
             }


         }*/
    }
}
