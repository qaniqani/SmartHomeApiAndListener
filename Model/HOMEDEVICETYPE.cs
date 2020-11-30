using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Model
{
    public class HOMEDEVICETYPE
    {
        [Key]
        public int LREF { get; set; }
        [Required]
        public string NAME { get; set; }
        [Required]
        public string DEVICETYPE { get; set; }
        [Required]
        public string BETWEENVALUE { get; set; }
        [Required]
        public int ISDETECTOR { get; set; }
        public string PINNR { get; set; }
        public string PICTURE { get; set; }
        public int SEQUENCENR { get; set; }
        [Required]
        public int STATUS { get; set; }
    }
}