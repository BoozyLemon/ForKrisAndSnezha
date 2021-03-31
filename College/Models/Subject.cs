namespace College.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Subject")]
    public partial class Subject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Subject()
        {
            Transcripts = new HashSet<Transcript>();
        }

        [Key]
        [StringLength(20)]
        public string Code { get; set; }

        [Required]
        [StringLength(500)]
        public string Name { get; set; }

        public short TotalHours { get; set; }

        public short? UDMDK { get; set; }

        public short? LabPract { get; set; }

        public short? CourseWork { get; set; }

        public short? Practice { get; set; }

        [StringLength(10)]
        public string IndependentWork { get; set; }

        public int? SemesterId { get; set; }

        public virtual Semester Semester { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transcript> Transcripts { get; set; }
    }
}
