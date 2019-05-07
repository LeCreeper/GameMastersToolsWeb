namespace GameMastersToolsWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Item")]
    public partial class Item
    {
        public int ItemId { get; set; }

        [Required]
        [StringLength(60)]
        public string ItemName { get; set; }

        [Required]
        public string ItemDescription { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
