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

namespace Equipment_accounting
{
    /// <summary>
    /// Логика взаимодействия для EditEquipmentWindow.xaml
    /// </summary>
    public partial class EditEquipmentWindow : Window
    {
        public main MainEdit { get; set; }

        public List<main> MainList { get; set; }
        public EditEquipmentWindow(main m)
        {
            InitializeComponent();
            //MainEdit = m;
            MainList = Helper.Connction.main.ToList();
            DataContext = this;
            Type.Text = m.equipment1.type_equipment.name_type;
            Title.Text = m.equipment1.title_equip;
            InvNumb.Text = m.inventory_numb;
            SerNumb.Text = m.serial_numb;
            Placement.Text = m.placement1.place.name_place;
            DateDel.Text=m.date_delivery;

        }
              
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Helper.Connction.SaveChanges();
            this.Close();
           
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            return;

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
            return;
        }
    }
}
