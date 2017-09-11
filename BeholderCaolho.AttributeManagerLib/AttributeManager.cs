using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeholderCaolho.AttributeManagerLib
{
    public class AttributeManager
    {
        private List<Attribute> attributes = new List<Attribute>();
        private List<AttributeModifier> modifiers = new List<AttributeModifier>();
        private List<CalcAttribute> calcAttributes = new List<CalcAttribute>();

        public float this[string _attr]
        {
            get
            {
                var attr = GetCalcAttr(_attr);
                if (attr != null) return attr.Value;
                else return 0;
            }
        }

        protected float this[string _attr, AttributeModifier.ModifierType _type]
        {
            get
            {
                return GetModSum(_attr, _type);
            }
        }

        protected CalcAttribute GetCalcAttr(string _name)
        {
            return Get(calcAttributes, _name) as CalcAttribute;
        }

        protected Attribute GetAttr(string _name)
        {
            return Get(attributes, _name);
        }

        protected Attribute Get<T>(List<T> _list, string _name) where T : Attribute
        {
            return _list.FirstOrDefault(a => a.Name.Equals(_name));
        }

        protected float GetModSum(string _name, AttributeModifier.ModifierType _type)
        {
            return modifiers.Where(m => m.type == _type).Sum(m => m.Value);
        }

        protected float GetModMax(string _name, AttributeModifier.ModifierType _type)
        {
            return modifiers.Where(m => m.type == _type).Max(m => m.Value);
        }

        public AttributeManager Add(Attribute _attr)
        {
            attributes.Add(_attr);
            calcAttributes.Add(new CalcAttribute(_attr, OnUpdate, () => { return (this[_attr.Name] + this[_attr.Name, AttributeModifier.ModifierType.Flat]) * (1 + this[_attr.Name, AttributeModifier.ModifierType.Percentual]); }));

            return this;
        }

        public AttributeManager Add(string _name, float _value)
        {
            return Add(new Attribute { Name = _name, Value = _value });
        }

        public AttributeManager Update(Attribute _attr)
        {
            var attr = attributes.FirstOrDefault(a => a.Name.Equals(_attr.Name));
            if (attr != null) attr.Value = _attr.Value;

            return this;
        }

        public AttributeManager Update(string _name, float _value)
        {
            return Update(new Attribute { Name = _name, Value = _value });
        }

        public AttributeManager AddModifier(AttributeModifier _attr)
        {
            modifiers.Add(_attr);

            var attr = GetCalcAttr(_attr.Name);
            if (attr != null) attr.UpdateValue();

            return this;
        }

        public AttributeManager AddModifier(string _name, float _value, AttributeModifier.ModifierType _type = AttributeModifier.ModifierType.Flat)
        {
            return AddModifier(new AttributeModifier { Name = _name, Value = _value, type = _type });
        }

        public AttributeManager UpdateModifier(AttributeModifier _attr, float _value)
        {
            var mod = modifiers.FirstOrDefault(a => a.Equals(_attr));
            if (mod != null) mod.Value = _value;

            var attr = GetCalcAttr(_attr.Name);
            if (attr != null) attr.UpdateValue();

            return this;
        }

        public AttributeManager RemoveModifier(AttributeModifier _attr)
        {
            attributes.Remove(_attr);

            var attr = GetCalcAttr(_attr.Name);
            if (attr != null) attr.UpdateValue();

            return this;
        }

        public AttributeManager SetUpdate(string _name, CalcAttribute.GetValueDelegate _update)
        {
            var calcAttr = calcAttributes.FirstOrDefault(a => a.Name.Equals(_name));
            if (calcAttr != null) calcAttr.GetValue = _update;

            return this;
        }

        public AttributeManager AddDependency(string _name, params string[] _list)
        {
            foreach (var s in _list)
            {
                var calc = GetCalcAttr(s);
                if (calc != null) calc.Updates.Add(_name);
            }

            return this;
        }

        public void UpdateAll()
        {
            foreach (var attr in calcAttributes)
            {
                attr.UpdateValue();
            }
        }

        private void OnUpdate(string _name)
        {
            var calc = GetCalcAttr(_name);

            foreach (var s in calc.Updates)
            {
                var update = GetCalcAttr(s);
                if (update != null) update.UpdateValue();
            }
        }
    }
}
