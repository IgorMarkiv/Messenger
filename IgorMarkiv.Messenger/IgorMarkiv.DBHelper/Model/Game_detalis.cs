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
    
    public partial class Game_detalis
    {
        public int id { get; set; }
        public long id_game { get; set; }
        public int id_stage { get; set; }
        public bool stage_answer_status { get; set; }
        public System.TimeSpan spent_time { get; set; }
        public int level { get; set; }
        public Nullable<int> stage_score { get; set; }
    }
}
