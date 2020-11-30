using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Model
{
    public class BLOK
    {
        [Key]
        public int LREF { get; set; }
        [Required]
        public string NAME { get; set; }
        [Required]
        public string TOPIC { get; set; }
        [Required]
        public int STATUS { get; set; }
    }
}