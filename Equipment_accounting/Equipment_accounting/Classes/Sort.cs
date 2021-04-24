using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Equipment_accounting.Model;

namespace Equipment_accounting.Classes
{
    class Sort
    {
        public static List<main> FilterList(List<main> source, string nameEquipment)
        {
            List<main> filter = new List<main>();
            foreach (var item in source)
            {
                if (item.equipment1.title_equip.Contains(nameEquipment))
                    filter.Add(item);

            }

            return filter;
        }


        public static List<main> FilterInvnubmList(List<main> source, string inventoryNumb)
        {
            List<main> filter = new List<main>();
            foreach (var item in source)
            {
                if (item.inventory_numb.Contains(inventoryNumb))
                    filter.Add(item);

            }

            return filter;
        }
    }
}
