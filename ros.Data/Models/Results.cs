namespace ros.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Results
    {
        [Key]
        public int ResultId { get; set; }

        public int RaceEventId { get; set; }

        public int TeamId { get; set; }

        public int BoatId { get; set; }

        [Required]
        [StringLength(50)]
        public string ResultTime { get; set; }

        [Required]
        [StringLength(50)]
        public string CalculatedResultTime { get; set; }

        public double ResultDistance { get; set; }

        public double CalculatedResultDistance { get; set; }

        public int Rank { get; set; }

        public int? Penalty { get; set; }

        public bool? IsDisqualified { get; set; }

        public virtual Boats Boats { get; set; }

        public virtual RaceEvents RaceEvents { get; set; }

        public virtual Teams Teams { get; set; }
    }
}
