//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBHelper.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            this.msg_conv1 = new HashSet<msg_conv>();
        }
    
        public int id { get; set; }
        public string user { get; set; }
        public string email { get; set; }
        public System.DateTime lastLogin { get; set; }
        public int invalidLogin { get; set; }
        public string password { get; set; }
        public string salt { get; set; }
    
        public virtual msg_conv msg_conv { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<msg_conv> msg_conv1 { get; set; }
    }
}
