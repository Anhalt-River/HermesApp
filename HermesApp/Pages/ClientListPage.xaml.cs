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

namespace HermesApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientListPage.xaml
    /// </summary>
    public partial class ClientListPage : Page
    {
        public ClientListPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Заполнить список клиентов. Происходит при инициализации
        /// </summary>
        private void FillClients()
        {

        }

        private void ReturnPageBut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        /// <summary>
        /// Элемент навигации по полученным клиентам на экране. Навигация назад
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Output_BackBut_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Элемент навигации по полученным клиентам на экране. Навигация вперед
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Output_ForwardBut_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Элемент сортировки. Сортировка по числу посещени
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sort_VisitsBut_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Элемент сортировки. Сортировка по последнему посещению
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sort_DatelastVisitBut_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Элемент сортировки. Сортировка по фамилии
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sort_LastNameBut_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Элемент фильтрации. Сбросить фильтрацию в труху
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Filtr_ThrowBut_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Элемент фильтрации. Фильтрация по полу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Filtr_GenderBut_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Навигация на страницу тегов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClientTagsBut_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
