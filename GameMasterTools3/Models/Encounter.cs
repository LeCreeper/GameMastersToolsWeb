namespace GameMasterTools3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Encounter")]
    public partial class Encounter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Encounter()
        {
            Obstacle = new HashSet<Obstacle>();
        }

        public int EncounterId { get; set; }

        [Required]
        [StringLength(60)]
        public string EncounterName { get; set; }

        [Required]
        public string EncounterDescription { get; set; }

        public int UserId { get; set; }

        public virtual Users Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Obstacle> Obstacle { get; set; }
    }
}
