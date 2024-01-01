using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace MaterialManagementSystem.Models
{
    [Table("Indent")]
    public class Indent
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime IndentDate  { get; set; }
        public string Item { get; set; }
        public string Description { get; set; }
        public string ItemCode { get; set; }
       
        public string IndentNo { get; set; }
      
        public string SourceFund { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReceivedDate { get; set; }
        public string Status { get; set; }
        public string Quantity { get; set; }
        public int IsActive { get; set; }
    }
}