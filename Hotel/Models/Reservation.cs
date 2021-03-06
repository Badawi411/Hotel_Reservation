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
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;



    public partial class Reservation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reservation()
        {
            this.Guests = new HashSet<Guest>();
            this.Rooms = new HashSet<Room>();
        }
    
        public int ReservationId { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }

        [DataType(DataType.Date)]
        public Nullable<System.DateTime> ReservationDate { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> CheckInDate { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> CheckOutDate { get; set; }
        public decimal Total { get; set; }



        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Guest> Guests { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
