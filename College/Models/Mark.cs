namespace College.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Mark")]
    public partial class Mark
    {
        public int Id { get; set; }

        public int TranscriptId { get; set; }

        public int StudentId { get; set; }

        public short? Written { get; set; }

        public short? Verbal { get; set; }

        public short Overall { get; set; }

        public virtual Student Student { get; set; }

        public virtual Transcript Transcript { get; set; }
    }
}
