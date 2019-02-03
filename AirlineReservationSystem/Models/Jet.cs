namespace AirlineReservationSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Jet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Jet()
        {
            Flights = new HashSet<Flight>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int JetID { get; set; }

        [Column(TypeName = "text")]
        public string JetName { get; set; }

        [Column(TypeName = "text")]
        public string JetType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Flight> Flights { get; set; }
    }
}
