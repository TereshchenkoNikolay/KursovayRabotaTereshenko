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

        private void forget_psw_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Извините, функционал находится в доработке.");
            Helper.GoNext(new recoverPassword(), this);
        }


        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            Process.GetCurrentProcess().Kill();
        }


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
        private void registation_Click(object sender, RoutedEventArgs e)
        {
            Helper.GoNextM(new registationWindow(), this);
        }


    }
}
