namespace Web_Prog_Project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        [Key]
        public int Admin_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Admin_Name { get; set; }

        [Required]
        [StringLength(20)]
        public string Admin_Email { get; set; }

        [Required]
        [StringLength(20)]
        public string Admin_Password { get; set; }

        [Required]
        [StringLength(20)]
        public string Admin_Contact { get; set; }
    }
}
