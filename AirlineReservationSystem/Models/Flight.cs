namespace AirlineReservationSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Flight
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Flight()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int FlightID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FlightDate { get; set; }

        public int? FlightJetID { get; set; }

        [Column(TypeName = "text")]
        public string FlightSource { get; set; }

        [Column(TypeName = "text")]
        public string FlightDestination { get; set; }

        [Column(TypeName = "text")]
        public string FlightTime { get; set; }

        public virtual Jet Jet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
