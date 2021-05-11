using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Equipment_accounting.Model;
using Equipment_accounting.Classes;
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
            ExportCmbBox.SelectedIndex = 0;
            DataContext = this;
        }
      //Обработчик изменений в комбобоксе с типами оборудования 
        private void typeCmbBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (typeCmbBox.SelectedIndex != -1)
                MainGrid.ItemsSource = Sort.FilterTypeList(MainList, (typeCmbBox.SelectedValue as type_equipment).name_type.ToString());
        }
        //Обработчик изменеий в поле ввода наименования 
        private void nameEquipTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (nameEquipTxtBox.Text != null)
                MainGrid.ItemsSource = Sort.FilterTitleList(MainList, nameEquipTxtBox.Text);
        }
        //Обработчик изменений в комбобоксе с местами расмещениями
        private void placementCmbBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (placementCmbBox.SelectedIndex != -1)
                MainGrid.ItemsSource = Sort.FilterPlacementList(MainList, (placementCmbBox.SelectedValue as place).name_place.ToString());
        }
        ///Обработчик изменеий в поле ввода инвентарного номера
        private void inventoryNumbTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (inventoryNumbTxtBox.Text != null)
                MainGrid.ItemsSource = Sort.FilterInventoryNumbList(MainList, inventoryNumbTxtBox.Text);
        }
        //Обработчик изменеий в поле ввода серийного номера
        private void serialNumbTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (serialNumbTxtBox.Text != null)
                MainGrid.ItemsSource = Sort.FilterSerialNumbList(MainList, serialNumbTxtBox.Text);
        }
        //Обработчик изменеий в поле ввода даты доставки
        private void delDateTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (delDateTxtBox.Text != null)
                MainGrid.ItemsSource = Sort.FilterDeliveryDateList(MainList, delDateTxtBox.Text);
        }
       // Обработчик изменеий в поле ввода даты добавления
        private void addDateTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (addDateTxtBox.Text != null)
                MainGrid.ItemsSource = Sort.FilterAddDateList(MainList, addDateTxtBox.Text);
        }
        //Обработчик кнопки информации
        private void infoButton_Click(object sender, RoutedEventArgs e)
        {
            //Передача информации в InfoWindow
            main m = MainGrid.SelectedItem as main;
            infoWindow iw = new infoWindow(m);
            iw.Show();
            iw.WindowState = WindowState.Normal;
        }
        //Обработчик кнопки информации
        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            Helper.GoNextM(new AddEquipment(), this);
        }
        //Обработчик загрузки окна
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
        //Обработчик кнопки редактирования
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
        //Обработчик кнопки удаления
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
        //Обработчик кнопки сброса фильтров
        private void ResetFiltersBtn_Click(object sender, RoutedEventArgs e)
        {
            addDateTxtBox.Text = "";
            delDateTxtBox.Text = "";
            nameEquipTxtBox.Text = "";
            serialNumbTxtBox.Text = "";
            inventoryNumbTxtBox.Text = "";
            placementCmbBox.SelectedIndex = -1;
            typeCmbBox.SelectedIndex = -1;
            MainGrid.ItemsSource = MainList;
        }

        //ОБработчик кнопки обновления таблицы
        private void updateBTN_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Items.Refresh();
        }
        //Обработчик кнопки сохрания
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
        //Обработчик кнопки возврата
        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            Helper.GoNext(new MainWindow(), this);
        }
        //Обработчики кнопок экспорта
        private void ExportPDfAndExcel_Click(object sender, RoutedEventArgs e)
        {

            Export.ExportPdf(MainGrid);
            Export.ExportExcel(MainGrid);
        }

        private void ExportPdfBtn_Click(object sender, RoutedEventArgs e)
        {
            Export.ExportPdf(MainGrid);
        }

        private void ExportExcelBtn_Click(object sender, RoutedEventArgs e)
        {
            Export.ExportExcel(MainGrid);
        }
    }
}
