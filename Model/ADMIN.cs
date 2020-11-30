using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class ADMIN
    {
        [Key]
        public int LREF { get; set; }
        [Required]
        public string NAME { get; set; }
        [Required]
        public string SURNAME { get; set; }
        [Required]
        public string USERNAME { get; set; }
        [Required]
        public string PASSWORD { get; set; }
        [Required]
        public int STATUS { get; set; }
        public DateTime DATETIME { get; set; }
    }
}