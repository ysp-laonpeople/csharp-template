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
using System.Windows.Shapes;

namespace BaseTemplate.Client1
{
    /// <summary>
    /// StartPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class StartPage : Window
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.labelA.Content = this.textboxA.Text;
            this.labelB.Content = this.textboxA.Text;
            this.labelC.Content = this.textboxA.Text;
            this.labelD.Content = this.textboxA.Text;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.labelA.Content = this.textboxB.Text;
            this.labelB.Content = this.textboxB.Text;
            this.labelC.Content = this.textboxB.Text;
            this.labelD.Content = this.textboxB.Text;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.labelA.Content = this.textboxC.Text;
            this.labelB.Content = this.textboxC.Text;
            this.labelC.Content = this.textboxC.Text;
            this.labelD.Content = this.textboxC.Text;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.labelA.Content = this.textboxD.Text;
            this.labelB.Content = this.textboxD.Text;
            this.labelC.Content = this.textboxD.Text;
            this.labelD.Content = this.textboxD.Text;
        }
    }
}
