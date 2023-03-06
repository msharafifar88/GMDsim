using bases;
using DAO;
using System.Collections.Generic;

namespace BL
{
    public class PropertyBL
    {
        public List<Property> findAll()
        {
            PropertyDAO propertyDAO = new PropertyDAO();
            return propertyDAO.findLoadPropery();
        }
    }
}
