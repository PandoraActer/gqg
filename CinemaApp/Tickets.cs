//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CinemaApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tickets
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tickets()
        {
            this.SaleTicket = new HashSet<SaleTicket>();
        }
    
        public int Id { get; set; }
        public int SessionId { get; set; }
        public int Row { get; set; }
        public int Seat { get; set; }
        public decimal Price { get; set; }
        public int IdUserAccount { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaleTicket> SaleTicket { get; set; }
        public virtual Session Session { get; set; }
        public virtual UserAccount UserAccount { get; set; }
    }
}
