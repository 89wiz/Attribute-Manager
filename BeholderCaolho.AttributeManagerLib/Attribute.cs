using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeholderCaolho.AttributeManagerLib
{
    public class Attribute
    {
        public delegate void OnUpdateDelegate(string attrName);
        public OnUpdateDelegate OnUpdate;

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
                OnUpdate?.Invoke(Name);
                this.value = value;
            }
        }
    }

    public class CalcAttribute : Attribute
    {
        public delegate float GetValueDelegate();
        public GetValueDelegate GetValue;
        
        public List<string> Updates { get; set; }

        public CalcAttribute(Attribute _attr, OnUpdateDelegate _onUpdate, GetValueDelegate _getValue)
        {
            Name = _attr.Name;
            Value = _attr.Value;
            OnUpdate = _onUpdate;
            GetValue = _getValue;

            Updates = new List<string>();
        }

        public void UpdateValue()
        {
            Value = GetValue();
            OnUpdate(Name);
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
