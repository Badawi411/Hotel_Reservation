//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Room
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Room()
        {
            this.Reservations = new HashSet<Reservation>();
        }
    
        public int RoomNumber { get; set; }
        public string RoomType { get; set; }
        public int StandardOccupancy { get; set; }
        public int MaximumOccupancy { get; set; }
        public decimal BasePrice { get; set; }
        public decimal ExtraPerson { get; set; }
        public bool Reserved { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
