namespace ros.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Teams
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Teams()
        {
            RaceEventTeams = new HashSet<RaceEventTeams>();
            Results = new HashSet<Results>();
            RegisteredUsers1 = new HashSet<RegisteredUsers>();
        }

        [Key]
        public int TeamId { get; set; }

        public int TeamNumber { get; set; }

        public int EntryId { get; set; }

        public int SkipperId { get; set; }

        public virtual Entries Entries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RaceEventTeams> RaceEventTeams { get; set; }

        public virtual RegisteredUsers RegisteredUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Results> Results { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegisteredUsers> RegisteredUsers1 { get; set; }
    }
}
