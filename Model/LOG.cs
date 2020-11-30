using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Model
{
    public class LOG
    {
        [Key]
        public int LREF { get; set; }
        [Required]
        public string QUERY { get; set; }
        [Required]
        public string QOSLEVEL { get; set; }
        [Required]
        public string RETAIN { get; set; }
        [Required]
        public string TOPIC { get; set; }
        [Required]
        public DateTime CREATEDATE { get; set; }
    }
}