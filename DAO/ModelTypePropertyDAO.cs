using bases;
using System.Collections.Generic;

namespace DAO
{
    public class ModelTypePropertyDAO
    {
        public List<ModelTypeProperty> findAll()
        {
            ModelTypeDAO modelTypeDAO = new ModelTypeDAO();
            PropertyDAO propertyDAO = new PropertyDAO();
            List<ModelType> modelTypes = new List<ModelType>();
            List<ModelTypeProperty> modelTypeProperties = new List<ModelTypeProperty>();
            foreach (ModelType model in modelTypes)
            {
                if (model.name.Contains("Generator"))
                {
                    List<Property> properties = propertyDAO.findGeneratorPropery();
                    ModelTypeProperty modelTypeProperty = new ModelTypeProperty(model, properties);
                    modelTypeProperties.Add(modelTypeProperty);
                }
                if (model.name.Contains("Bus"))
                {
                    List<Property> properties = propertyDAO.findBusPropery();
                    ModelTypeProperty modelTypeProperty = new ModelTypeProperty(model, properties);
                    modelTypeProperties.Add(modelTypeProperty);
                }
                if (model.name.Contains("Load"))
                {
                    List<Property> properties = propertyDAO.findLoadPropery();
                    ModelTypeProperty modelTypeProperty = new ModelTypeProperty(model, properties);
                    modelTypeProperties.Add(modelTypeProperty);
                }
                if (model.name.Contains("TransFormer"))
                {
                    List<Property> properties = propertyDAO.findTransFormer_ControlPropery();
                    ModelTypeProperty modelTypeProperty = new ModelTypeProperty(model, properties);
                    modelTypeProperties.Add(modelTypeProperty);
                }
            }
            return modelTypeProperties;
        }



    }
}
