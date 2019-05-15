namespace GameMasterTools3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CampaignPC")]
    public partial class CampaignPC
    {
        public int CampaignPCId { get; set; }

        public int CampaignId { get; set; }

        public int PCId { get; set; }

        public virtual Campaign Campaign { get; set; }

        public virtual PC PC { get; set; }
    }
}
