//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SheaduleASP
{
    using System;
    using System.Collections.Generic;
    
    public partial class AUDITORIUM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AUDITORIUM()
        {
            this.TIMETABLE = new HashSet<TIMETABLE>();
        }
    
        public int AUDITORIUM_CODE { get; set; }
        public string BUILDING { get; set; }
        public Nullable<int> CAPACITY { get; set; }
        public string AUDITORIUM_NUMBER { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TIMETABLE> TIMETABLE { get; set; }
    }
}