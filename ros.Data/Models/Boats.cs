namespace ros.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Boats
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Boats()
        {
            Entries = new HashSet<Entries>();
            Results = new HashSet<Results>();
        }

        [Key]
        public int BoatId { get; set; }

        public int SailNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string BoatName { get; set; }

        public double Hcp { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string BoatType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Entries> Entries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Results> Results { get; set; }
    }
}
