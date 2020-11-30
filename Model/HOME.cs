using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Model
{
    public class HOME
    {
        [Key]
        public int LREF { get; set; }
        [Required]
        public int BLOKREF { get; set; }
        [StringLength(23, ErrorMessage = "Home client id max length 23 characters.")]
        [Required]
        public string CLIENTID { get; set; }
        [Required]
        public string NAME { get; set; }
        public string PICTURE { get; set; }
        [Required]
        public int SMARTHOMESTATUS { get; set; }
        [Required]
        public int STATUS { get; set; }
    }
}