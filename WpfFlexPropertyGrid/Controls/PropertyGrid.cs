using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace WpfFlexPropertyGrid.Controls
{
    public class PropertyGrid : Control
    {
        /// <summary>
        /// Identifies the <see cref="SelectedObject"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty SelectedObjectProperty = DependencyProperty.Register(
            nameof(SelectedObject),
            typeof(object),
            typeof(PropertyGrid),
            new UIPropertyMetadata(null, (s, e) => ((PropertyGrid)s).OnSelectedObjectChanged(e)));

        /// <summary>
        /// Identifies the <see cref="PropertyEditorTemplateSelector"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PropertyEditorTemplateSelectorProperty = DependencyProperty.Register(
            nameof(PropertyEditorTemplateSelector),
            typeof(object),
            typeof(PropertyGrid),
            new UIPropertyMetadata(null, (s, e) => ((PropertyGrid)s).OnPropertyEditorTemplateSelectorChanged(e)));



        ///// <summary>
        ///// Panel part name.
        ///// </summary>
        //private const string PartPanel = "PART_Panel";

        ///// <summary>
        ///// ScrollViewer part name.
        ///// </summary>
        //private const string PartScrollViewer = "PART_ScrollViewer";

        private const string PartItemsControl = "PART_ItemsControl";

        /// <summary>
        /// Gets or sets the selected object.
        /// </summary>
        /// <value>The selected object.</value>
        public object SelectedObject { get => GetValue(SelectedObjectProperty); set => SetValue(SelectedObjectProperty, value); }
        //public PropertyEditorTemplateSelector? PropertyEditorTemplateSelector { get => (PropertyEditorTemplateSelector)GetValue(PropertyEditorTemplateSelectorProperty); set => SetValue(PropertyEditorTemplateSelectorProperty, value); }

        //private readonly Obser<PropertyViewItem> properties = new ObservableList<PropertyViewItem>();

        private List<PropertyItem> _propertyItems;
        //private Panel? _itemsPanel;
        //private ScrollViewer? _scrollViewer;
        private ItemsControl? _itemsControl;



        /*
         * PropertyGrid: コンポーネントひとつ分
         * PropertyGridList: 
         */
        static PropertyGrid()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyGrid), new FrameworkPropertyMetadata(typeof(PropertyGrid)));
        }

        public PropertyGrid()
        {
            _propertyItems = new();
        }
        
        /// <summary>
        /// Called when the selected object is changed.
        /// </summary>
        /// <param name="e">The e.</param>
        protected void OnSelectedObjectChanged(DependencyPropertyChangedEventArgs e)
        {
            //TreeView;
            //this.CurrentObject = this.SelectedObject;
            UpdateControls();
        }

        protected void OnPropertyEditorTemplateSelectorChanged(DependencyPropertyChangedEventArgs e)
        {
            //UpdateControls();
        }

        private void UpdateControls()
        {
            if (_itemsControl == null) return;

            var selectedObject = SelectedObject;
            if (selectedObject == null) return;

            _propertyItems.Clear();
            var properties = TypeDescriptor.GetProperties(SelectedObject);


            _itemsControl.ItemTemplateSelector = new PropertyEditorTemplateSelector();


            //HierarchicalDataTemplate a;

            
            //var editorSelector = PropertyEditorTemplateSelector ?? PropertyEditorTemplateSelector.Default;

            foreach (var prop in properties)
            {
                var item = new PropertyItem((PropertyDescriptor)prop);
                _propertyItems.Add(item);
            }
            _itemsControl.ItemsSource = _propertyItems;


            //var dataTemplate = editorSelector.SelectTemplate(prop.GetType());

            //dataTemplate.
        }
        
        /// <summary>
        /// When overridden in a derived class, is invoked whenever application code or internal processes call <see
        /// cref="M:System.Windows.FrameworkElement.ApplyTemplate" /> .
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            //_itemsPanel = Template.FindName(PartPanel, this) as Panel;
            //_scrollViewer = Template.FindName(PartScrollViewer, this) as ScrollViewer;
            _itemsControl = Template.FindName(PartItemsControl, this) as ItemsControl;
            UpdateControls();
        }

    }
}