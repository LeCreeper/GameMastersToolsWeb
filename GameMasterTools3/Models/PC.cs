namespace GameMasterTools3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PC")]
    public partial class PC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PC()
        {
            CampaignPC = new HashSet<CampaignPC>();
        }

        public int PCId { get; set; }

        [Required]
        [StringLength(60)]
        public string PCName { get; set; }

        [Required]
        public string PCDescription { get; set; }

        public int UserId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CampaignPC> CampaignPC { get; set; }

        public virtual Users Users { get; set; }
    }
}
