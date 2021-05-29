using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using Equipment_accounting.Model;
namespace Equipment_accounting
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<users> UserList { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            UserList = Helper.Connction.users.ToList();
        }
        //Обработчик кнопки восстаноления пароля
        private void forget_psw_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBox.Show("Извините, в текущей версии программы отправить пароль Вам на почту невозможно, обратитесь к системному администратору вашей площадки. ", "Обращение", button, icon);
            // Helper.GoNext(new recoverPassword(), this);
        }
        //Обработчик кнопки выхода
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            Process.GetCurrentProcess().Kill();
        }
        //Обработчик кнопки авторизации
        private void log_in_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(EmailTextbox.Text) || String.IsNullOrWhiteSpace(Password.Password))
            {
                MessageBox.Show("Должны быть заполнены все поля ");
                return;
            }
            foreach (users u in UserList)
            {
                if (u.email == EmailTextbox.Text && u.password == Password.Password)
                {
                    Helper.CurrentUser = u;
                    Helper.GoNextM(new WorkingWindow(), this);
                    return;
                }
                else
                {
                    MessageBox.Show("Email и/или пароль введен(ы) неверно! ");
                }
            }
                    }
        //Обработчик кнопки регистрации
        private void registation_Click(object sender, RoutedEventArgs e)
        {
            Helper.GoNextM(new registationWindow(), this);
        }
    }
}
