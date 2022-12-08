using StroitelnayaCompaniyaApp.FailiDannih;
using StroitelnayaCompaniyaApp.Stranici;
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

namespace StroitelnayaCompaniyaApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            PodclucheniyeOdb.podcluchObj = new z3_4_BalashovaEntities();
            NavigaciyaObj.frmNavigaciya = FrmNavigaciya;

            FrmNavigaciya.Navigate(new PageGlavnayaForma());
        }

        private void BtnNazad_Click(object sender, RoutedEventArgs e)
        {
            if (NavigaciyaObj.frmNavigaciya.CanGoBack)
            {
                NavigaciyaObj.frmNavigaciya.GoBack();
            }
        }

        private void BtnVxod_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
