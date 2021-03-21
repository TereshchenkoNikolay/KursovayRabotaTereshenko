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
using System.Windows.Shapes;
using Equipment_accounting.Model;
namespace Equipment_accounting
{
    /// <summary>
    /// Логика взаимодействия для AddEquipment.xaml
    /// </summary>
    public partial class AddEquipment : Window
    {
        public List<main> MainListAdd { get; set; }
        public List<equipment> EquipmentAdd { get; set; }
        public List<provider> ProviderAdd { get; set; }
        main NewMain = new main();
        public AddEquipment()
        {
            InitializeComponent();
            MainListAdd = Helper.Connction.main.ToList();
            EquipmentAdd = Helper.Connction.equipment.ToList();
            ProviderAdd = Helper.Connction.provider.ToList();
            DataContext = this;
        }
        
        private void cancelBTn_Click(object sender, RoutedEventArgs e)
        {
            Helper.GoNextM(new WorkingWindow(), this);
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CheckEquip())
            {
                AddEquip();
                MessageBox.Show((title_equipCMB.SelectedItem as equipment).title_equip + "\tдобавлено в базу с инвентарным номером:\t" + inventoryNumbTXTBox.Text);
                this.Close();

            }
            else MessageBox.Show("Добавление не удалось");
        }
        //метод для проверки
        bool CheckEquip()
        {//пропущено обязательное поле
            if (dateDelDP == null || inventoryNumbTXTBox.Text == "" || serialNumbTxtBox.Text == "" || title_equipCMB.SelectedItem == null || providerCMB.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля!!!");
                return false;
            }
            //Есть ли такое оборудование
            foreach (main m in MainListAdd)
            {
                NewMain = m;
                if (NewMain.inventory_numb == inventoryNumbTXTBox.Text || NewMain.serial_numb == serialNumbTxtBox.Text || NewMain.inventory_numb == inventoryNumbTXTBox.Text && NewMain.serial_numb == serialNumbTxtBox.Text)
                {
                    MessageBox.Show("Такое оборудование уже есть в базе!");
                    return false;
                }
            }
            return true;
        }
        //Получение ID оборудования по заданному наименованию
        int GetIdE(string s)
        {
            List<equipment> list = Helper.Connction.equipment.ToList();
            foreach (equipment eq in list)
            {
                if (eq.title_equip == s)
                {
                    return eq.id_equipment;
                }
            }
            return 0;
        }
        //Получение ID по заданному названию
        int GetIdP(string s)
        {
            List<provider> list = Helper.Connction.provider.ToList();
            foreach (provider pr in list)
            {
                if (pr.name_provider == s)
                {
                    return pr.id_provider;
                }
            }
            return 0;
        }
        //Метод добавления 
        public void AddEquip()
        {            //Через метод
            string s = (title_equipCMB.SelectedItem as equipment).title_equip;
            int eq_id = GetIdE(s);
            string s1 = (providerCMB.SelectedItem as provider).name_provider;
            int prov_id = GetIdP(s1);

            NewMain.Id_equipment = eq_id;
            NewMain.id_provider = prov_id;
            NewMain.date_delivery = dateDelDP.Text;
            DateTime dt = DateTime.Now;
            string curDate = dt.ToShortDateString();
            NewMain.date_add_to_db = curDate;
            NewMain.serial_numb = serialNumbTxtBox.Text;
            NewMain.inventory_numb = inventoryNumbTXTBox.Text;
            NewMain.id_placement = 1;
            Helper.Connction.main.Add(NewMain);
            Helper.Connction.SaveChanges();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            Helper.GoNextM(new WorkingWindow(), this);
        }
    }
}



