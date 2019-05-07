namespace GameMastersToolsWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Chapter")]
    public partial class Chapter
    {
        public int ChapterId { get; set; }

        [Required]
        [StringLength(60)]
        public string ChapterName { get; set; }

        public string ChapterDescription { get; set; }

        public int CampaignId { get; set; }

        public virtual Campaign Campaign { get; set; }
    }
}
