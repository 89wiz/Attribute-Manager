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
        private List<Attribute> calcAttributes = new List<Attribute>();

        public float this[string _attr]
        {
            get
            {
                var attr = calcAttributes.FirstOrDefault(a => a.Name.Equals(_attr));
                if (attr != null) return calcAttributes.FirstOrDefault(a => a.Name.Equals(_attr)).Value;
                else return 0;
            }
        }

        public Attribute GetCalcAttr(string _name)
        {
            return Get(calcAttributes, _name);
        }

        public Attribute GetAttr(string _name)
        {
            return Get(attributes, _name);
        }

        private Attribute Get(List<Attribute> _list, string _name)
        {
            return _list.FirstOrDefault(a => a.Name.Equals(_name));
        }

        public AttributeManager Add(Attribute _attr)
        {
            attributes.Add(_attr);
            calcAttributes.Add(_attr);

            _attr.onUpdate = OnUpdate;

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

        public AttributeManager SetUpdate(string _name, Attribute.Update _update)
        {
            var attr = attributes.FirstOrDefault(a => a.Name.Equals(_name));
            if (attr != null) attr.update = _update;

            return this;
        }

        private void OnUpdate(string _name)
        {
            foreach (var attr in calcAttributes)
            {
                if (attr.Depends.Contains(_name)) attr.update();
            }
        }

        private void OnUpdate(Attribute _attr)
        {
            foreach (var s in _attr.Updates)
            {
                var attr = GetCalcAttr(s);
                if (attr != null) attr.update();
            }
        }
    }
}
