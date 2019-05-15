namespace GameMasterTools3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Obstacle")]
    public partial class Obstacle
    {
        public int ObstacleId { get; set; }

        [Required]
        [StringLength(60)]
        public string ObstacleName { get; set; }

        [Required]
        public string ObstacleDescription { get; set; }

        public int EncounterId { get; set; }

        public virtual Encounter Encounter { get; set; }
    }
}
