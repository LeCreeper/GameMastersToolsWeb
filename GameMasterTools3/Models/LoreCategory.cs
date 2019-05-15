namespace GameMasterTools3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoreCategory")]
    public partial class LoreCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoreCategory()
        {
            LoreSubject = new HashSet<LoreSubject>();
        }

        public int LoreCategoryId { get; set; }

        [Required]
        [StringLength(60)]
        public string LoreCategoryName { get; set; }

        [Required]
        [StringLength(450)]
        public string LoreCategoryDescription { get; set; }

        public int UserId { get; set; }

        public virtual Users Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoreSubject> LoreSubject { get; set; }
    }
}
