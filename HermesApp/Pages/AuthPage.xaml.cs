using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        private bool isRememberMe = false;
        private int countAttempts = 0;
        public AuthPage()
        {
            InitializeComponent();
            FillRememberLogin();
        }

        private void FillRememberLogin()
        {
            if (Properties.Settings.Default.Remember_Login != "")
            {
                LoginBox.Text = Properties.Settings.Default.Remember_Login;
            }
        }

        private void AuthBut_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.Remember_BlockTime == new DateTime())
            {
                AuthCourse();
            }
            else
            {
                if (Properties.Settings.Default.Remember_BlockTime < DateTime.Now)
                {
                    Properties.Settings.Default.Remember_BlockTime = new DateTime();
                    AuthCourse();
                }
                else
                {
                    var time_remain = Properties.Settings.Default.Remember_BlockTime - DateTime.Now;
                    Properties.Settings.Default.Save();

                    MessageBox.Show($"Авторизация невозможна ввиду блокировки. До конца блокировки осталось: {time_remain.TotalSeconds.ToString().Split(',')[0]} секунд",
                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        /// <summary>
        /// Допуск до авторизации. Если число попыток превысит три, то произойдет инициализация блокировки
        /// </summary>
        private void AuthCourse()
        {
            if (countAttempts > 2)
            {
                var time_block = DateTime.Now;
                time_block = time_block.AddMinutes(Properties.Settings.Default.Block_Minuts);
                Properties.Settings.Default.Remember_BlockTime = time_block;
                Properties.Settings.Default.Save();
                countAttempts = 0;

                MessageBox.Show($"Вы исчерпали допустимое количество попыток при неверности введенного пароля! Повторное введение пароля возможно только через {Properties.Settings.Default.Block_Minuts} минут", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    var search_user = App.Connection.User.Where(x => x.Login == LoginBox.Text).FirstOrDefault();

                    if (search_user != null)
                    {
                        if (search_user.Password == PasswordBox.Password)
                        {
                            if (isRememberMe)
                            {
                                Properties.Settings.Default.Remember_Login = search_user.Login;
                            }
                            //Переход на другую страницу       
                            MessageBox.Show("Авторизация прошла успешно", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                            NavigationService.Navigate(new ClientListPage());
                        }
                        else
                        {
                            countAttempts++;
                            MessageBox.Show($"Неправильный пароль! Осталось попыток: {3 - countAttempts}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Не удалось найти аккаунт с заданным логином!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception e)
                {
                    Debug.Write($"{e}");
                }
            }
        }

        private void RememberCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            isRememberMe = true;
        }

        private void RememberCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            isRememberMe = false;
        }

        private void CreateUserBut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }
    }
}
