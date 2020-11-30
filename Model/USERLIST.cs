using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Model
{
    public class USERLIST
    {
        [Key]
        public int LREF { get; set; }
        public string BLOKNAME { get; set; }
        public string HOMENAME { get; set; }
        public int USERTYPE { get; set; }
        public string HOMECLIENTID { get; set; }
        public string NAME { get; set; }
        public string SURNAME { get; set; }
        public DateTime BIRTHDATE { get; set; }
        public string EMAIL { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string PASSWORD2 { get; set; }
        public string GSMNR { get; set; }
        public int SMARTHOMESTATUS { get; set; }
        public int STATUS { get; set; }
    }
}