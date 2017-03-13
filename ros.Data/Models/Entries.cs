namespace ros.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Entries
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Entries()
        {
            RegattaEntries = new HashSet<RegattaEntries>();
            RegisteredUsers = new HashSet<RegisteredUsers>();
            Teams = new HashSet<Teams>();
        }

        [Key]
        public int EntryId { get; set; }

        public int EntryNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string EntryName { get; set; }

        public DateTime RegistrationDate { get; set; }

        public double AmountPaid { get; set; }

        public int UserId { get; set; }

        public int ClubId { get; set; }

        public int? BoatId { get; set; }

        public virtual Boats Boats { get; set; }

        public virtual Clubs Clubs { get; set; }

        public virtual Users Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegattaEntries> RegattaEntries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegisteredUsers> RegisteredUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Teams> Teams { get; set; }
    }
}
