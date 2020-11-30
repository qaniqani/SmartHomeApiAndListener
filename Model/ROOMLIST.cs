using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Model
{
    public class ROOMLIST
    {
        [Key]
        public int LREF { get; set; }
        public int HOMEREF { get; set; }
        public string BLOKNAME { get; set; }
        public string HOMENAME { get; set; }
        public string NAME { get; set; }
        public string PICTURE { get; set; }
        public int STATUS { get; set; }
    }
}