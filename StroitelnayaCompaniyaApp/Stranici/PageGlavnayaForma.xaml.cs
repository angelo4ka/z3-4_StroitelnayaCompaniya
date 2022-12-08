using StroitelnayaCompaniyaApp.FailiDannih;
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

namespace StroitelnayaCompaniyaApp.Stranici
{
    /// <summary>
    /// Interaction logic for PageGlavnayaForma.xaml
    /// </summary>
    public partial class PageGlavnayaForma : Page
    {
        public PageGlavnayaForma()
        {
            InitializeComponent();
        }

        private void BtnSklad_Click(object sender, RoutedEventArgs e)
        {
            NavigaciyaObj.frmNavigaciya.Navigate(new PageSklad());
        }

        private void BtnStroimateriali_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnVidiMaterialov_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EdiniciIzmereniya_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
