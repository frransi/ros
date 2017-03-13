namespace ros.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Events
    {
        [Key]
        public int EventId { get; set; }

        public int RegattaId { get; set; }

        public int ContactAddressId { get; set; }

        [Required]
        [StringLength(50)]
        public string EventName { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public int EventFee { get; set; }

        public int? MaxAmountOfParticipants { get; set; }

        public virtual ContactAddresses ContactAddresses { get; set; }

        public virtual Regattas Regattas { get; set; }

        public virtual RaceEvents RaceEvents { get; set; }

        public virtual SocialEvents SocialEvents { get; set; }
    }
}
