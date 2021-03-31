namespace College.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Transcript")]
    public partial class Transcript
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Transcript()
        {
            Marks = new HashSet<Mark>();
        }

        public int Id { get; set; }

        public int CategoryId { get; set; }

        [Required]
        [StringLength(20)]
        public string SubjectCode { get; set; }

        public int GroupId { get; set; }

        [Required]
        [StringLength(20)]
        public string SpecialId { get; set; }

        public int EmployeeId { get; set; }

        public short NumberOfHours { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Group Group { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mark> Marks { get; set; }

        public virtual Specialty Specialty { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual TranscriptCategory TranscriptCategory { get; set; }
    }
}
