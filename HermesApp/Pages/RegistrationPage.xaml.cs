using HermesApp.Data;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void ReturnPageBut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void RegistrationBut_Click(object sender, RoutedEventArgs e)
        {
            var search_user = App.Connection.User.Where(x=> x.Login == LoginBox.Text).FirstOrDefault();
            if (search_user != null)
            {
                MessageBox.Show("Пользователь с заданным ником уже существует", "Ошибка в логине", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }

            bool isPasswordFormalized = PasswordInspection();
            if (isPasswordFormalized)
            {
                try
                {
                    User new_user = new User()
                    {
                        Login = LoginBox.Text,
                        Password = PasswordBox.Text,
                    };
                    App.Connection.User.Add(new_user);
                    App.Connection.SaveChanges();

                    MessageBox.Show("Аккаунт успешно создан", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception)
                {
                    Debug.Write($"{e}");
                    MessageBox.Show("При создании аккаунта возникли независящие от вас ошибки. Обратитесь в службу поддержки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Пароль недостаточно сложен. Правила указания пароля описаны в подсказке при наведении на поле пароля", "Ошибка в пароле", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private bool PasswordInspection()
        {
            string taked_password = PasswordBox.Text;
            if (taked_password.Length < 6)
            {
                return false;
            }

            bool isCapitalSymbolTaked = false;
            foreach(char symbol in taked_password)
            {
                if (Char.IsUpper(symbol))
                {
                    isCapitalSymbolTaked = true;
                    break;
                }
            }

            bool isCifrusTaked = false;
            foreach (char symbol in taked_password)
            {
                if (!Char.IsLetterOrDigit(symbol))
                {
                    isCifrusTaked = true;
                    break;
                }
            }

            bool isSpecSymbolTaked = false;
            foreach (char symbol in taked_password)
            {
                if (symbol == '!' || symbol == '@' || symbol == '#' || symbol == '$' || symbol == '%' || symbol == '^')
                {
                    isSpecSymbolTaked = true;
                    break;
                }
            }

            if (isCapitalSymbolTaked && isCifrusTaked && isSpecSymbolTaked)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
