using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using Equipment_accounting.Model;
namespace Equipment_accounting
{
    /// <summary>
    /// Логика взаимодействия для registationWindow.xaml
    /// </summary>
    public partial class registationWindow : Window
    {//TODO:Адаптивная верстка
        public List<users> UserListReg { get; set; }
        users NewUser = new users();
        public registationWindow()
        {
            InitializeComponent();
            UserListReg = Helper.Connction.users.ToList();
          
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Helper.GoNext(new MainWindow(), this);
        }

        private void okBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Checkuser())
            {
                Addusers();
                //завершение регистрации
                MessageBox.Show("Отлично, " + FioTxtbox.Text + ", вы успешно зарегистрировались!");
                Helper.GoNext(new MainWindow(), this);

            }
            else MessageBox.Show("Регистрации не случилось :(");
        }
        public void Addusers()
        { 
          
            NewUser.fio_users = FioTxtbox.Text;
            NewUser.email = EmailTxtbox.Text;
            NewUser.password = Password.Password;
            NewUser.dateofbirth = dateofbirth.Text;

            if (adminRB.IsChecked == true) NewUser.id_type = 2;
            else NewUser.id_type = 1;

            Helper.Connction.users.Add(NewUser);
            Helper.Connction.SaveChanges();

        }
        bool Checkuser()
        {            //проверка символов пароля
            Regex reg = new Regex(@"^(?=.*[a-z])");
            Regex reg1 = new Regex(@"^(?=.*[A-Z])");

            Regex reg2 = new Regex(@"^(?=.*[1-9])");
            Regex reg3 = new Regex(@"^(?=.*[а-я])");
            Regex reg4 = new Regex(@"^(?=.*[А-Я])");

            //пропущено обязательное поле
            if (FioTxtbox.Text == "" || EmailTxtbox.Text == "" || Password.Password == "" || confirmPassword.Password == "")
            {
                MessageBox.Show("Заполните обязательные поля!!!");
                return false;
            }
            //Неформатный  пароль
            if (!reg.IsMatch(Password.Password.ToString()) || !reg1.IsMatch(Password.Password.ToString()) || !reg2.IsMatch(Password.Password.ToString()) || reg3.IsMatch(Password.Password.ToString()) || reg4.IsMatch(Password.Password.ToString()))
            {
                MessageBox.Show("Пароль должен содержать < 8 символов и хотя бы одну заглавную букву , прописную букву и цифру");
                return false;
            }
            //пароли не совпадают
            if (Password.Password != confirmPassword.Password)
            {
                MessageBox.Show("Значения в полях \"Пароль\" и \"Подтверждение пароля\" не совпадают");
                return false;
            }


            //Не занят ли логин
            foreach (users u in UserListReg)
            {
                NewUser = u;
                if (NewUser.email == EmailTxtbox.Text)
                {
                    MessageBox.Show("Логин занят, придумайте другой!");
                    return false;
                }
            }
                return true;
                
            }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            Helper.GoNext(new MainWindow(), this);
        }
    }
    }








