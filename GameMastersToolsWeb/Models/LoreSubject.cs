namespace GameMastersToolsWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoreSubject")]
    public partial class LoreSubject
    {
        public int LoreSubjectId { get; set; }

        [Required]
        [StringLength(60)]
        public string LoreSubjectName { get; set; }

        [Required]
        public string LoreSubjectDescription { get; set; }

        public int LoreCategoryId { get; set; }

        public virtual LoreCategory LoreCategory { get; set; }
    }
}
