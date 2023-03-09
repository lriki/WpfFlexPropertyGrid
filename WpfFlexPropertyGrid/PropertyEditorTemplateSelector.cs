using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace WpfFlexPropertyGrid
{
    //[ContentProperty("Items")]
    internal class PropertyEditorTemplateSelector : DataTemplateSelector
    {
        public static PropertyEditorTemplateSelector Default
        {
            get
            {
                if (_default == null)
                {
                    _default = new PropertyEditorTemplateSelector();
                    _default.Items = new();


                    var dictionary = (ResourceDictionary)Application.LoadComponent(new Uri("/WpfFlexPropertyGrid;component/Themes/PropertyEditorTemplateProviders.xaml", UriKind.RelativeOrAbsolute));
                    foreach (object value in dictionary.Values)
                    {
                        var provider = value as PropertyEditorTemplateProvider;
                        if (provider != null)
                        {
                            if (provider.Template.DataType == null)
                            {
                                provider.Template.DataType = provider.Type;
                            }
                            _default.Items.Add(provider.Template);
                        }
                    };
                }
                return _default;
            }
        }
        private static PropertyEditorTemplateSelector? _default;


        public List<DataTemplate> Items { get; set; }

        
        
        public PropertyEditorTemplateSelector()
        {
            Items = new List<DataTemplate>();
        }

        public override DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            var propertyItem = (PropertyItem)item;
            
            var template = Items.Find((dt) => propertyItem.PropertyType.Equals(dt.DataType));
            if (template != null) return template;

            template = Default.Items.Find((dt) => propertyItem.PropertyType.Equals(dt.DataType));
            if (template != null) return template;


            return base.SelectTemplate(item, container);
        }
    }
}
