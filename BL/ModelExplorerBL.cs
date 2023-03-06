using bases;
using DAO;
using System;
using System.Collections.Generic;
namespace BL
{
    public class ModelExplorerBL
    {


        public List<ModelType> createRootTree()
        {
            List<String> root = new List<String> { "Network" };

            long l = 1;
            List<ModelType> modelTypes = new List<ModelType>();
            foreach (String name in root)
            {
                ModelType modelType = new ModelType();
                modelType.name = name;
                modelType.code = l + 1;
                modelType.leaf = false;
                modelTypes.Add(modelType);
            }

            return modelTypes;

        }

        public List<ModelType> createChildTree()
        {
            ModelTypeDAO modelTypeDAO = new ModelTypeDAO();
            List<ModelType> child = modelTypeDAO.findAll();


            List<ModelType> modelTypes = new List<ModelType>();
            foreach (ModelType modelType in child)
            {

                modelType.leaf = true;
                modelTypes.Add(modelType);
            }

            return modelTypes;

        }

        public ModelType findModelType(String s)
        {
            ModelTypeDAO modelTypeDAO = new ModelTypeDAO();
            List<ModelType> modelTypes = modelTypeDAO.findAll();
            foreach (ModelType model in modelTypes)
            {
                if (model.name.Equals(s))
                {
                    return model;
                }
            }
            return null;
        }
    }
}
