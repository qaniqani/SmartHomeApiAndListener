using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Model
{
    public class USER
    {
        public USER()
        {
                BIRTHDATE = new DateTime(1900, 1, 1).Date;
        }
        [Key]
        public int LREF { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public int USERTYPE { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string HOMECLIENTID { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string NAME { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string SURNAME { get; set; }
        public DateTime BIRTHDATE { get; set; }
        public string EMAIL { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string USERNAME { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string PASSWORD { get; set; }
        [Compare("PASSWORD", ErrorMessage = "Şifre uyuşmuyor."), Required(ErrorMessage = "Bu alan zorunludur.")]
        public string PASSWORD2 { get; set; }
        public string GSMNR { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public int SMARTHOMESTATUS { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public int STATUS { get; set; }
    }
}