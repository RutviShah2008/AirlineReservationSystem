namespace AirlineReservationSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ticket
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TicketID { get; set; }

        [Column(TypeName = "text")]
        public string TicketType { get; set; }

        public int? PassengerID { get; set; }

        public int? FlightType { get; set; }

        public virtual Flight Flight { get; set; }

        public virtual Passenger Passenger { get; set; }
    }
}
