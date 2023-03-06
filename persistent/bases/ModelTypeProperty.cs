using System.Collections.Generic;

namespace bases
{
    public class ModelTypeProperty
    {
        public ModelTypeProperty(ModelType model, ICollection<Property> properties)
        {
            this.model = model;
            this.properties = properties;
        }

        public ModelType model { get; set; }
        public ICollection<Property> properties { get; set; }
    }
}
