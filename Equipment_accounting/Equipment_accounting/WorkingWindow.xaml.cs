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

namespace Equipment_accounting
{
    /// <summary>
    /// Логика взаимодействия для WorkingWindow.xaml
    /// </summary>
    public partial class WorkingWindow : Window
    {
        public List<main> MainList { get; set; }
        public List<type_equipment> TypeList { get; set; }
        public List<place> PlaceList { get; set; }
        public List<equipment> EquipmentList { get; set; }
        public List<users> UserList { get; set; }
        public WorkingWindow()
        {
            InitializeComponent();
            MainList = Helper.Connction.main.ToList();
            TypeList = Helper.Connction.type_equipment.ToList();
            PlaceList = Helper.Connction.place.ToList();
            DataContext = this;
        }
        private void typeCmbBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            Sort();
        }
        private void nameEquipTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Sort();
        }
        private void placementCmbBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            Sort();
        }
        private void inventoryNumbTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Sort();
        }
        private void serialNumbTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Sort();
        }
        private void delDateTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Sort();
        }
        private void addDateTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Sort();
        }
        private void Sort()
        {
            try
            {
                //Выбор по 1 полю
                if (typeCmbBox.SelectedValue != null)
                {
                    MainList = Helper.Connction.main.ToList().Where(m => m.equipment1.type_equipment.name_type == (typeCmbBox.SelectedItem as type_equipment).name_type).ToList();
                }
                if (placementCmbBox.SelectedValue != null)
                {
                    MainList = Helper.Connction.main.ToList().Where(m => m.placement1.place.name_place == (placementCmbBox.SelectedItem as place).name_place).ToList();
                }
                if (inventoryNumbTxtBox.Text != "")
                {
                    MainList = Helper.Connction.main.ToList().Where(m => m.inventory_numb == inventoryNumbTxtBox.Text).ToList();
                }
                if (nameEquipTxtBox.Text != "")
                {
                    MainList = Helper.Connction.main.ToList().Where(m => m.equipment1.title_equip == nameEquipTxtBox.Text).ToList();
                }
                if (serialNumbTxtBox.Text != "")
                {
                    MainList = Helper.Connction.main.ToList().Where(m => m.serial_numb == serialNumbTxtBox.Text).ToList();
                }
                if (delDateTxtBox.Text != "")
                {
                    MainList = Helper.Connction.main.ToList().Where(m => m.date_delivery == delDateTxtBox.Text).ToList();
                }
                if (addDateTxtBox.Text != "")
                {
                    MainList = Helper.Connction.main.ToList().Where(m => m.date_add_to_db == addDateTxtBox.Text).ToList();
                }
                //TODO:Выбор нескольким  полям
                // if (placementCmbBox.SelectedValue != null && typeCmbBox.SelectedValue != null)
                //  {
                //    MainList = Helper.Connction.main.ToList().Where(m => m.equipment1.type_equipment.name_type == (typeCmbBox.SelectedItem as type_equipment).name_type).ToList();
                //    MainList = MainList.ToList().Where(m => m.placement1.place.name_place == (placementCmbBox.SelectedItem as place).name_place).ToList();

                //}
                MainGrid.ItemsSource = MainList;
            }
            catch (Exception ex)
            { }
        }
        private void infoButton_Click(object sender, RoutedEventArgs e)
        {
            main m = MainGrid.SelectedItem as main;
            infoWindow iw = new infoWindow(m);
            iw.Show();
            iw.WindowState = WindowState.Normal;
        }
        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            
            Helper.GoNextM(new AddEquipment(),this);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            if (Helper.CurrentUser.type_users.name_type_u == "administrator")
            {
                addBtn.Visibility = Visibility.Visible;
                SaveBtn.Visibility = Visibility.Visible;
            }
            else
            {
                addBtn.Visibility = Visibility.Hidden;
                SaveBtn.Visibility = Visibility.Hidden;
            }
        }
        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            if (Helper.CurrentUser.type_users.name_type_u == "administrator")
            {
                title_equipDGTC.IsReadOnly = false;
                inventory_numbDGTC.IsReadOnly = false;
                serial_numbDGTC.IsReadOnly = false;
                name_placeDGTC.IsReadOnly = false;
                date_deliveryDGTC.IsReadOnly = false;
            }
            else MessageBox.Show("Недостаточно прав для выполнения данной операции. ");
        }
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (Helper.CurrentUser.type_users.name_type_u == "administrator")
            {
                main m = MainGrid.SelectedItem as main;
            Helper.Connction.main.Remove(m);
            Helper.Connction.SaveChanges();
            MessageBox.Show("Оборудование удалено");
            }
            else MessageBox.Show("Недостаточно прав для выполнения данной операции. ");

        }
        private void ResetFiltersBtn_Click(object sender, RoutedEventArgs e)
        {
            MainList = Helper.Connction.main.ToList();
            DataContext = null;
            DataContext = this;
        }

        private void updateBTN_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Items.Refresh();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            title_equipDGTC.IsReadOnly = true;
            inventory_numbDGTC.IsReadOnly = true;
            serial_numbDGTC.IsReadOnly = true;
            name_placeDGTC.IsReadOnly = true;
            date_deliveryDGTC.IsReadOnly = true;
            Helper.Connction.SaveChanges();
            MessageBox.Show("Изменения сохранены.");
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            Helper.GoNext(new MainWindow(), this);
        }
    }
}
