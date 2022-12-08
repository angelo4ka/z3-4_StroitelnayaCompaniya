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
    /// Interaction logic for PageSkladDobRedact.xaml
    /// </summary>
    public partial class PageSkladDobRedact : Page
    {
        Sklad _sklad;

        public PageSkladDobRedact(Sklad sklad)
        {
            InitializeComponent();

            _sklad = sklad;
            var VidiMaterialov = new List<int>(PodclucheniyeOdb.podcluchObj.VidStroimaterialov.Select(x => x.ID).ToList()); ;
            CmbxVidMaterialov.ItemsSource = PodclucheniyeOdb.podcluchObj.VidStroimaterialov.ToList();
            // Заполнение данных формы при редактировании
            if (sklad != null)
            {
                CmbxVidMaterialov.SelectedIndex = VidiMaterialov.IndexOf(sklad.VidStroimaterialovID);
                TbxAdres.Text = sklad.Adres;
                TbxRasstoyanie.Text = Convert.ToString(sklad.Rasstoyanie);
            }
        }

        private void BtnSohranit_Click(object sender, RoutedEventArgs e)
        {
            VidStroimaterialov vid = (VidStroimaterialov)CmbxVidMaterialov.SelectedItem;
            if (_sklad != null) // Редактирование
            {
                try
                {
                    IEnumerable<Sklad> skladi = PodclucheniyeOdb.podcluchObj.Sklad.Where(x => x.ID == _sklad.ID).AsEnumerable().Select(x =>
                    {
                        x.VidStroimaterialovID = vid.ID;
                        x.Adres = TbxAdres.Text;
                        x.Rasstoyanie = Convert.ToInt32(TbxRasstoyanie.Text);

                        return x;
                    });

                    foreach (Sklad sklad in skladi)
                    {
                        PodclucheniyeOdb.podcluchObj.Entry(sklad).State = System.Data.Entity.EntityState.Modified;
                    }

                    PodclucheniyeOdb.podcluchObj.SaveChanges();
                    MessageBox.Show("Данные успешно изменены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message.ToString());
                }
            }
            else // Добавление
            {
                try
                {
                    Sklad sklad = new Sklad()
                    {
                        VidStroimaterialovID = vid.ID,
                        Adres = TbxAdres.Text,
                        Rasstoyanie = Convert.ToInt32(TbxRasstoyanie.Text)
                    };

                    PodclucheniyeOdb.podcluchObj.Sklad.Add(sklad);
                    PodclucheniyeOdb.podcluchObj.SaveChanges();
                    MessageBox.Show("Данные успешно добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message.ToString());
                }
            }
        }
    }
}
