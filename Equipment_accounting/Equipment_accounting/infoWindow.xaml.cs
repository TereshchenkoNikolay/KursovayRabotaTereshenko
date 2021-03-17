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
using System.Windows.Shapes;
using Equipment_accounting.Model;
namespace Equipment_accounting
{
    /// <summary>
    /// Логика взаимодействия для infoWindow.xaml
    /// </summary>
    public partial class infoWindow : Window
    {
        public List<main> MainList { get; set; }
        
      
        public infoWindow(main m)
        {
            InitializeComponent();

            MainList = Helper.Connction.main.ToList();
            
           idLbl.Content = m.id_main;
            typeEquipLbl.Content = m.equipment1.type_equipment.name_type;
            nameEquipLbl.Content = m.equipment1.title_equip;
            
            descriptionEquipTxtBlock.Text = m.equipment1.description;
           
            placementLbl.Content = m.placement1.place.name_place;
            datePlaceLbl.Content = m.placement1.date_moving;
            DataContext = this;
        }

        

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
      this.Close();
            return;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            
        }
    }
}
