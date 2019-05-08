namespace GameMastersToolsWeb2.Models
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
            Obstacles = new HashSet<Obstacle>();
        }

        public int EncounterId { get; set; }

        [Required]
        [StringLength(60)]
        public string EncounterName { get; set; }

        [Required]
        public string EncounterDescription { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Obstacle> Obstacles { get; set; }
    }
}
