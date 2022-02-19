using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabExam1.Models
{
    public class Product
    {
       [Key]
        public int ProductId { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Enter product NameProduct Name ")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Enter Product Rate ")]
        public decimal Rate { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter discription for  ")]
        public string Description { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "please enter catagory of produvt")]
        public string CategoryName { get; set; }
    }
}