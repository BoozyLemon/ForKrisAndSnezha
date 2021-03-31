namespace College.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            Transcripts = new HashSet<Transcript>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(254)]
        public string LastName { get; set; }

        [Required]
        [StringLength(254)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(254)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(32)]
        public string Login { get; set; }

        [Required]
        [StringLength(32)]
        public string Password { get; set; }

        public bool? IsFired { get; set; }

        public int CategoryId { get; set; }

        public int RoleId { get; set; }

        public virtual EmployeeCategory EmployeeCategory { get; set; }

        public virtual Role Role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transcript> Transcripts { get; set; }
        #region

        [NotMapped]
        public virtual string FullName { get { return LastName + " " + FirstName + " " + MiddleName; } }

        #endregion
    }
}
