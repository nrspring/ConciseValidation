using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConciseValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConciseValidation_UnitTests.Support
{
    public class DynamicTestItem<T> : DynamicObject, IDynamicValidation
    {
        public DynamicTestItem()
        {
            _properties = new Dictionary<string, T>();
        }

        private readonly Dictionary<string, T> _properties;
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (_properties.ContainsKey(binder.Name))
            {
                result = _properties[binder.Name];
                return true;
            }
            else
            {
                result = default(T);
                return false;
            }
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (_properties.ContainsKey(binder.Name))
            {
                _properties[binder.Name] = (T)value;
            }
            else
            {
                _properties.Add(binder.Name, (T)value);
            }

            return true;
        }

        public object GetPropertyValue(string propertyName)
        {
            if (_properties.ContainsKey(propertyName))
            {
                return _properties[propertyName];
            }

            return null;
        }
    }
}
