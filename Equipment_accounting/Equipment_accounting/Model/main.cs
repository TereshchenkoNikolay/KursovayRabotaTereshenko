//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Equipment_accounting.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class main
    {
        public int id_main { get; set; }
        public int Id_equipment { get; set; }
        public int id_provider { get; set; }
        public string date_delivery { get; set; }
        public string date_add_to_db { get; set; }
        public string inventory_numb { get; set; }
        public string serial_numb { get; set; }
        public int id_placement { get; set; }
    
        public virtual provider provider { get; set; }
        public virtual equipment equipment1 { get; set; }
        public virtual placement placement1 { get; set; }
    }
}