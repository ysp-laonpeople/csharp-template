using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BaseTemplate.Client4.Control
{
    /// <summary>
    /// WaitIndicator.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class WaitIndicator : UserControl
    {
        public WaitIndicator()
        {
            InitializeComponent();
        }
        protected static void OnDescriptionProperty(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }
        public static DependencyProperty DescriptionProperty = DependencyProperty.Register(nameof(Description), typeof(string), typeof(WaitIndicator),
          new PropertyMetadata(OnDescriptionProperty)
          {
              DefaultValue = string.Empty,
          });
        public string Description
        {
            get=> (string)this.GetValue(DescriptionProperty);
            set=> this.SetValue(DescriptionProperty, value);
        }
    }
}
