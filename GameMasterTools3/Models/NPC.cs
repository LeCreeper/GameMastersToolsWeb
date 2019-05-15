namespace GameMasterTools3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NPC")]
    public partial class NPC
    {
        public int NPCId { get; set; }

        [Required]
        [StringLength(60)]
        public string NPCName { get; set; }

        [Required]
        public string NPCDescription { get; set; }

        public int UserId { get; set; }

        public virtual Users Users { get; set; }
    }
}
