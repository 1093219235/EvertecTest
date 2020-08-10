using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvertecTest.Entities
{
    public class login
    {
        [Display(Name = "E-MAIL")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Key]
        [StringLength(120, MinimumLength = 5, ErrorMessage = "El E-mail debe estar entre 5 y 120 caracteres")]
        [Required]
        public string customer_email { get; set; }
        [Required]
        [StringLength(20)]
        public string password { get; set; }
        [StringLength(1)]
        public string admin { get; set; }
    }
}
