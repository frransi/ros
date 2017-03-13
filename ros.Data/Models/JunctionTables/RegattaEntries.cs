namespace ros.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RegattaEntries
    {
        [Key]
        public int RegattaEntryId { get; set; }

        public int EntryId { get; set; }

        public int RegattaId { get; set; }

        public virtual Entries Entries { get; set; }

        public virtual Regattas Regattas { get; set; }
    }
}
