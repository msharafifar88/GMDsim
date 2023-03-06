using bases;
using DAO;
using System.Collections.Generic;

namespace BL
{
    public class ModelTypePropertyBL
    {
        public List<Property> findProperiesByModelType(ModelType modelType)
        {
            ModelTypePropertyDAO dao = new ModelTypePropertyDAO();
            List<ModelTypeProperty> modelTypeProperties = dao.findAll();
            foreach (ModelTypeProperty typeProperty in modelTypeProperties)
            {
                if (typeProperty.model.name.Equals(modelType.name))
                {
                    return new List<Property>(typeProperty.properties);
                }
            }
            return new List<Property>();
        }
    }
}
