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
    /// Interaction logic for PageSklad.xaml
    /// </summary>
    public partial class PageSklad : Page
    {
        /// <summary>
        /// Тип сортировки: true - по возрастанию; false - по убыванию
        /// </summary>
        public static bool TipSortirovki = true;

        public PageSklad()
        {
            InitializeComponent();

            DtgdSkladi.ItemsSource = ZapolnitVidMaterialov(PodclucheniyeOdb.podcluchObj.Sklad.ToList());

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += UpdateData;
            timer.Start();
        }

        public void UpdateData(object sender, object e)
        {
            // Получаем все записи из БД
            var Skladi = PodclucheniyeOdb.podcluchObj.Sklad.ToList();

            Skladi = PoiskSkladov(Skladi);
            Skladi = SortirovkaSkladov(Skladi);

            DtgdSkladi.ItemsSource = ZapolnitVidMaterialov(Skladi);
        }

        /// <summary>
        /// Поиск складов по адресу
        /// </summary>
        /// <param name="Skladi">Список cкладов</param>
        /// <returns>Склады соответствующие поиску</returns>
        private List<Sklad> PoiskSkladov(List<Sklad> Skladi)
        {
            string ParametrPoiska = TbxPoisk.Text;
            if (ParametrPoiska != (string)TbxPoisk.Tag)
            {
                Skladi = Skladi.Where(x => x.Adres.Contains(ParametrPoiska)).ToList();
            }

            return Skladi;
        }

        /// <summary>
        /// Сортировка складов по адресу
        /// </summary>
        /// <param name="Skladi">Список cкладов</param>
        /// <returns>Отсортированный список складов</returns>
        private List<Sklad> SortirovkaSkladov(List<Sklad> Skladi)
        {
            ComboBoxItem CmbxZnacheniyeSortirovki = (ComboBoxItem)CmbxSortirovka.SelectedItem;
            if (CmbxZnacheniyeSortirovki.Content.ToString() != "Без сортировки")
            {
                if (TipSortirovki)
                {
                    switch ((string)CmbxZnacheniyeSortirovki.Tag)
                    {
                        case "ID":
                            return Skladi = Skladi.OrderBy(x => x.ID).ToList();

                        case "Adres":
                            return Skladi = Skladi.OrderBy(x => x.Adres).ToList();

                        case "Rasstoyanie":
                            return Skladi = Skladi.OrderBy(x => x.Rasstoyanie).ToList();

                        default:
                            break;
                    }
                }
                else
                {
                    switch ((string)CmbxZnacheniyeSortirovki.Tag)
                    {
                        case "ID":
                            return Skladi = Skladi.OrderByDescending(x => x.ID).ToList();

                        case "Adres":
                            return Skladi = Skladi.OrderByDescending(x => x.Adres).ToList();

                        case "Rasstoyanie":
                            return Skladi = Skladi.OrderByDescending(x => x.Rasstoyanie).ToList();

                        default:
                            break;
                    }
                }
            }




            string ParametrPoiska = TbxPoisk.Text;
            if (ParametrPoiska != (string)TbxPoisk.Tag)
            {
                Skladi = Skladi.Where(x => x.Adres.Contains(ParametrPoiska)).ToList();
            }

            return Skladi;
        }

        /// <summary>
        /// Заполнение данных о виде стройматериалов по ID
        /// </summary>
        /// <param name="Skladi">Список cкладов</param>
        /// <returns>Склады с заполненной информацией</returns>
        private List<Sklad> ZapolnitVidMaterialov(List<Sklad> Skladi)
        {
            var VidiMaterialov = PodclucheniyeOdb.podcluchObj.VidStroimaterialov.ToList();

            foreach (var sklad in Skladi)
            {
                var vidMaterialov = VidiMaterialov.Where(x => x.ID.Equals(sklad.VidStroimaterialovID)).ToList();
                sklad.VidMaterialovText = vidMaterialov[0].Naimenovaniye;
            }

            return Skladi;
        }

        private void BtnDobavit_Click(object sender, RoutedEventArgs e)
        {
            NavigaciyaObj.frmNavigaciya.Navigate(new PageSkladDobRedact(null));
        }

        private void BtnUdalit_Click(object sender, RoutedEventArgs e)
        {
            Sklad sklad = (Sklad)DtgdSkladi.SelectedItem;

            if (sklad != null)
            {
                try
                {
                    PodclucheniyeOdb.podcluchObj.Sklad.Remove(sklad);
                    PodclucheniyeOdb.podcluchObj.SaveChanges();

                    MessageBox.Show("Данные успешно удалены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message.ToString());
                }
            }
            else
            {
                MessageBox.Show("Не выделена строка для удаления.", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnRedactirovat_Click(object sender, RoutedEventArgs e)
        {
            Sklad sklad = (Sklad)DtgdSkladi.SelectedItem;

            if (sklad != null)
            {
                NavigaciyaObj.frmNavigaciya.Navigate(new PageSkladDobRedact(sklad));
            }
            else
            {
                MessageBox.Show("Не выделена строка для редактирования.", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        /// <summary>
        /// Выбор способа сортировки (по возрастанию и убыванию)
        /// </summary>
        private void BtnVidSortirovki_Click(object sender, RoutedEventArgs e)
        {
            // Если сортировка по возрастанию
            if ((string)BtnVidSortirovki.Content == "↓")
            {
                BtnVidSortirovki.Content = "↑";
                BtnVidSortirovki.ToolTip = "Сортировать по возрастанию";
                TipSortirovki = false;
            }
            else
            {
                BtnVidSortirovki.Content = "↓";
                BtnVidSortirovki.ToolTip = "Сортировать по убыванию";
                TipSortirovki = true;
            }
        }

        private void TbxPoisk_GotFocus(object sender, RoutedEventArgs e)
        {
            TbxPoisk.Text = "";
        }
    }
}
