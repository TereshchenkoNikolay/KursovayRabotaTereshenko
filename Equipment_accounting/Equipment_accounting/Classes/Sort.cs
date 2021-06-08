using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Equipment_accounting.Model;

namespace Equipment_accounting.Classes
{
    class Sort
    {    //Фильтр по  наименованию
        public static List<main> FilterTitleList(List<main> source, string nameEquipment)
        {
            List<main> filter = new List<main>();
            foreach (var item in source)
            {
                if (item.equipment1.title_equip.Contains(nameEquipment))
                    filter.Add(item);
            }
                        return filter;
        }
        //Фильтр по инвентарному номеру
        public static List<main> FilterInventoryNumbList(List<main> source, string inventoryNumb)
        {
            List<main> filter = new List<main>();
            foreach (var item in source)
            {
                if (item.inventory_numb.Contains(inventoryNumb))
                    filter.Add(item);
            }
            return filter;
        }
        //Фильтр по типу
        public static List<main> FilterTypeList(List<main> source, string type)
        {
            List<main> filter = new List<main>();
            foreach (var item in source)
            {
                if (item.equipment1.type_equipment.name_type == type)
                    filter.Add(item);
            }
            return filter;
        }
        //Фильтр по расположению
        public static List<main> FilterPlacementList(List<main> source, string placement)
        {

            List<main> filter = new List<main>();
            foreach (var item in source)
            {
                if (item.placement1.place.name_place == placement)
                    filter.Add(item);
            }
            return filter;
        }

        //фильтр по серийному номеру
        public static List<main> FilterSerialNumbList(List<main> source, string serialNumb)
        {
            List<main> filter = new List<main>();
            foreach (var item in source)
            {
                if (item.serial_numb.Contains(serialNumb))
                    filter.Add(item);
            }
            return filter;
        }
        //Фильтр по дате поставки
        public static List<main> FilterDeliveryDateList(List<main> source, string delDate)
        {
            List<main> filter = new List<main>();
            foreach (var item in source)
            {
                if (item.date_delivery.Contains(delDate))
                    filter.Add(item);
            }
            return filter;
        }
        //Фильтр по дате добавления
        public static List<main> FilterAddDateList(List<main> source, string addDate)
        {
            List<main> filter = new List<main>();
            foreach (var item in source)
            {
                if (item.date_add_to_db.Contains(addDate))
                    filter.Add(item);
            }
            return filter;
        }

    }
}


