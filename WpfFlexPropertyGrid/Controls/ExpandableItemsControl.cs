using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfFlexPropertyGrid.Controls
{
    public class ExpandableItemsControl : HeaderedItemsControl
    {
        /// <summary>
        /// Identifies the <see cref="IsExpanded"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsExpandedProperty = DependencyProperty.Register(nameof(IsExpanded), typeof(bool), typeof(ExpandableItemsControl), new FrameworkPropertyMetadata(false, OnIsExpandedChanged));
        
        /// <summary>
        /// Gets or sets whether this control is expanded.
        /// </summary>
        public bool IsExpanded { get { return (bool)GetValue(IsExpandedProperty); } set { SetValue(IsExpandedProperty, value); } }
        

        private static void OnIsExpandedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var item = (ExpandableItemsControl)d;
            var isExpanded = (bool)e.NewValue;

            //if (isExpanded)
            //    item.OnExpanded(new RoutedEventArgs(ExpandedEvent, item));
            //else
            //    item.OnCollapsed(new RoutedEventArgs(CollapsedEvent, item));
        }
    }
}
