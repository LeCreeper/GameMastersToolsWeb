namespace GameMastersToolsWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Location")]
    public partial class Location
    {
        public int LocationId { get; set; }

        [Required]
        [StringLength(60)]
        public string LocationName { get; set; }

        [Required]
        public string LocationDescription { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
