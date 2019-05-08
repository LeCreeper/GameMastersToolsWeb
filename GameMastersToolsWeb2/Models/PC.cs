namespace GameMastersToolsWeb2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PC")]
    public partial class PC
    {
        public int PCId { get; set; }

        [Required]
        [StringLength(60)]
        public string PCName { get; set; }

        [Required]
        public string PCDescription { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
