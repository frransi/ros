namespace ros.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Regattas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Regattas()
        {
            Events = new HashSet<Events>();
            RegattaEntries = new HashSet<RegattaEntries>();
        }

        [Key]
        public int RegattaId { get; set; }

        public int ClubId { get; set; }

        public int ContactAddressId { get; set; }

        public int ContactPersonId { get; set; }

        [Required]
        [StringLength(50)]
        public string RegattaName { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public int RegattaFee { get; set; }

        [Required]
        [StringLength(50)]
        public string RegattaDescription { get; set; }

        public int? MaxAmountOfEntries { get; set; }

        public virtual Clubs Clubs { get; set; }

        public virtual ContactAddresses ContactAddresses { get; set; }

        public virtual ContactPersons ContactPersons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Events> Events { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegattaEntries> RegattaEntries { get; set; }
    }
}
