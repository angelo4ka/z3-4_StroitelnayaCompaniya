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
using System.Windows.Threading;

namespace StroitelnayaCompaniyaApp.Stranici
{
    /// <summary>
    /// Interaction logic for PageStroimateriali.xaml
    /// </summary>
    public partial class PageStroimateriali : Page
    {
        public PageStroimateriali()
        {
            InitializeComponent();

            DtgdStroimateriali.ItemsSource = PodclucheniyeOdb.podcluchObj.Stroimaterial.ToList();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += UpdateData;
            timer.Start();
        }

        public void UpdateData(object sender, object e)
        {
            // Получаем все записи из БД
            DtgdStroimateriali.ItemsSource = PodclucheniyeOdb.podcluchObj.Stroimaterial.ToList();
        }
        private void TbxPoisk_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void BtnVidSortirovki_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDobavit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnUdalit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnRedactirovat_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
