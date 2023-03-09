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
    [ContentProperty("Template")]
    public class PropertyEditorTemplateProvider : DependencyObject
    {
        public Type Type { get; set; } = typeof(int);


        public DataTemplate Template { get; set; } = new DataTemplate();
    }
}
