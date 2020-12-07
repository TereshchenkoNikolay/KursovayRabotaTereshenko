using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Equipment_accounting
{
    /// <summary>
    /// Логика взаимодействия для recoverPassword.xaml
    /// </summary>
     
    public partial class recoverPassword : Window
    {
        public List<users> UserListRec { get; set; }
        public recoverPassword()
        {
            InitializeComponent();
            UserListRec = Helper.Connction.users.ToList();
        }

        private void sendbutton_Click(object sender, RoutedEventArgs e)
        {/*
            if (String.IsNullOrWhiteSpace(EmailForRecoverTxtbox.Text) )
            {
                MessageBox.Show("Должны быть заполнены все поля ");
                return;
            }
            foreach (users u in UserList)
            {

                // отправитель - устанавливаем адрес и отображаемое в письме имя
                MailAddress from = new MailAddress("moctt123@yandex.ru", "Nick");
                // кому отправляем
                MailAddress to = new MailAddress(EmailForRecoverTxtbox.Text);
                // создаем объект сообщения
                MailMessage m = new MailMessage(from, to);
                // тема письма
                m.Subject = "< h2 > Восстановление пароля </ h2 >";
                // текст письма
                if (EmailForRecoverTxtbox.Text == u.email)
                    m.Body = "Ваш пароль: " + u.password;
                else MessageBox.Show("Такого пользователя не существует!");
                // письмо представляет код html
                m.IsBodyHtml = true;
                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 25);
                // логин и пароль
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("moctt123@yandex.ru", "Rrr123rrr456");
               
                smtp.Send(m);
                MessageBox.Show("Сообщение отправлено");
                this.Close();
                Process.GetCurrentProcess().Kill();
            */
           
            }  
        }
    }

