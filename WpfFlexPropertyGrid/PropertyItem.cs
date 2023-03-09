using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfFlexPropertyGrid
{
    public class PropertyItem
    {
        public PropertyDescriptor Descriptor { get; init; }

        public Type PropertyType => Descriptor.PropertyType;

        //public object Value { get => GetValue(); set => SetValue(value); }

        public PropertyItem(PropertyDescriptor propertyDescriptor)
        {
            Descriptor = propertyDescriptor;
        }

        //private object GetValue()
        //{

        //}
        //private void SetValue(object value)
        //{

        //}
    }
}
