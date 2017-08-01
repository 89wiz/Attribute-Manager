using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeholderCaolho.AttributeManagerLib
{
    public class Attribute
    {
        public delegate void OnUpdate(string name);
        public OnUpdate onUpdate;

        public List<string> Dependences { get; set; }
        public List<string> Updates { get; set; }
        
        public string Name { get; set; }

        private float value;
        public float Value
        {
            get
            {
                return value;
            }
            set
            {
                onUpdate(Name);
                this.value = value;
            }
        }
    }

    public class AttributeModifier : Attribute
    {
        public enum ModifierType
        {
            Flat,
            Percentual
        }

        public ModifierType type;
    }
}
