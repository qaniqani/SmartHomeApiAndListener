using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Model
{
    public class HOMELIST
    {
        [Key]
        public int LREF { get; set; }
        public int BLOKREF { get; set; }
        public string BLOKNAME { get; set; }
        public string CLIENTID { get; set; }
        public string NAME { get; set; }
        public string PICTURE { get; set; }
        public int SMARTHOMESTATUS { get; set; }
        public int STATUS { get; set; }
    }
}