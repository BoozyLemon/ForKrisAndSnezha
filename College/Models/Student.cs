namespace College.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            Marks = new HashSet<Mark>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(254)]
        public string LastName { get; set; }

        [Required]
        [StringLength(254)]
        public string FirstName { get; set; }

        [StringLength(254)]
        public string MiddleName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }

        [StringLength(254)]
        public string Email { get; set; }

        [StringLength(25)]
        public string Phone { get; set; }

        [Required]
        [StringLength(32)]
        public string Login { get; set; }

        [StringLength(32)]
        public string Password { get; set; }

        [StringLength(254)]
        public string Adrress { get; set; }

        public int GenderId { get; set; }

        public int GroupId { get; set; }

        public bool? IsExpelled { get; set; }

        public byte[] Photo { get; set; }

        public virtual Gender Gender { get; set; }

        public virtual Group Group { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mark> Marks { get; set; }

        #region Important

        [NotMapped]
        public virtual string FullName { get { return LastName + " " + FirstName + " " + MiddleName; } }

        [NotMapped]
        public virtual string GroupNumber { get { return Group.Number + " группа"; } }

        #endregion
    }
}
