namespace ros.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RegisteredUserSocialEvents
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SocialEventId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RegisteredUserId { get; set; }

        public int? AmountOfFriends { get; set; }

        public virtual RegisteredUsers RegisteredUsers { get; set; }

        public virtual SocialEvents SocialEvents { get; set; }
    }
}
