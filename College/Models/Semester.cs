namespace College.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Semester")]
    public partial class Semester
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Semester()
        {
            Subjects = new HashSet<Subject>();
        }

        public int Id { get; set; }

        public int Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Subject> Subjects { get; set; }

        [NotMapped]
        public virtual ICollection<Mark> Marks
        {
            get
            {
                //using (var db = new CollegeDB())
                //{
                //    var transcripts = Subjects.Select(c => c.Transcripts).ToList();
                //    return .Select(f => f.Select(x => x.Marks.ToList()).ToList());
                //}
                return null;
            }
        }


    }
}
