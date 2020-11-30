using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Model
{
    public class ROOM
    {
        [Key]
        public int LREF { get; set; }
        [Required]
        public int HOMEREF { get; set; }
        [Required]
        public string NAME { get; set; }
        public string PICTURE { get; set; }
        [Required]
        public int STATUS { get; set; }
    }
}