namespace Web_Prog_Project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    public partial class Product
    {
        [Key]
        public int Product_ID { get; set; }

        [Required]
        [StringLength(200)]
        public string Product_Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Product_Description { get; set; }

        [Required]
        [StringLength(2000)]
        public string Product_Picture { get; set; }
       
        [NotMapped]
        public HttpPostedFileBase P_img { get; set; }

        [NotMapped]
        public int qty { get; set; }

        public int Product_Sale_Price { get; set; }

        public int Product_Purchase_Price { get; set; }

        public int Catagory_F_ID { get; set; }

        public virtual Catagory Catagory { get; set; }
    }
}
