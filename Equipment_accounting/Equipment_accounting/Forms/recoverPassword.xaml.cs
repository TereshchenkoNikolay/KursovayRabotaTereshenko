using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Windows;
using Equipment_accounting.Model;
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
        {
            //if (String.IsNullOrWhiteSpace(EmailForRecoverTxtbox.Text))
            //{
            //    MessageBox.Show("Поле должно быть заполнено ");
            //    return;
            //}
            //foreach (users u in UserListRec)
            //{

            //    // отправитель - устанавливаем адрес и отображаемое в письме имя
            //    MailAddress from = new MailAddress("tereshenkon.work@gmail.com", "Nick.Support");
            //    // кому отправляем
            //    MailAddress to = new MailAddress(EmailForRecoverTxtbox.Text);
            //    // создаем объект сообщения
            //    MailMessage m = new MailMessage(from, to);
            //    // тема письма
            //    m.Subject = "< h2 > Восстановление пароля </ h2 >";
            //    // текст письма
            //    if (EmailForRecoverTxtbox.Text == u.email)
            //        m.Body = "Ваш пароль: " + u.password;
            //    else MessageBox.Show("Такого пользователя не существует!");
            //    // письмо представляет код html
            //    m.IsBodyHtml = true;
            //    // адрес smtp-сервера и порт, с которого будем отправлять письмо
            //    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            //    // логин и пароль
            //    smtp.EnableSsl = true;
            //    smtp.Credentials = new NetworkCredential("tereshenkon.work@gmail.com", "Rrr123rrr456");

            //    smtp.Send(m);
            //    MessageBox.Show("Сообщение отправлено");
            //    this.Close();
            //    Process.GetCurrentProcess().Kill();


            //  }
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBoxButton button = MessageBoxButton.OK;
            if(MessageBox.Show("Извините, в текущей версии программы отправить пароль Вам на почту невозможно, обратитесь к системному администратору вашей площадки. ", "Обращение", button, icon) == MessageBoxResult.OK){
                Helper.GoNext(new MainWindow(), this);
            }
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            Helper.GoNext(new MainWindow(), this);
        }
    }
}

