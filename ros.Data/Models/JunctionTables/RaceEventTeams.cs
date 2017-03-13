namespace ros.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RaceEventTeams
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TeamId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RaceEventId { get; set; }

        [Required]
        [StringLength(50)]
        public string StartLocation { get; set; }

        [Required]
        [StringLength(50)]
        public string EndLocation { get; set; }

        public virtual RaceEvents RaceEvents { get; set; }

        public virtual Teams Teams { get; set; }
    }
}
