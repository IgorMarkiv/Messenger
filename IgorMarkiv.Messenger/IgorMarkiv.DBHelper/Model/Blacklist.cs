//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Helix.DBHelper.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Blacklist
    {
        public int id { get; set; }
        public Nullable<System.DateTime> until { get; set; }
        public int user_id { get; set; }
    
        public virtual Users Users { get; set; }
    }
}
