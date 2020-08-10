using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEvertecTest.DTO
{
    public class ordersDTO
    {
       
        public int id { get; set; }
        [Display(Name = "Nombre")]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "El nombre debe estar entre 3 y 80 caracteres")]
        [Required]
        public string customer_name { get; set; }
        [Display(Name ="E-MAIL Comprador")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [StringLength(120, MinimumLength = 5, ErrorMessage = "El E-mail debe estar entre 5 y 120 caracteres")]
        [Required]
        public string customer_email { get; set; }
        [Required]
        [Display(Name = "Celular")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Por favor entre un Nro Celular valido")]
        public string customer_mobile { get; set; }
        [MaxLength(20)]
        [Display(Name = "Estado Orden")]
        public string status { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de Creacion")]
        public DateTime created_at { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Ultima actualizacion")]
        public DateTime updated_at { get; set; }
        [Display(Name = "Precio")]
        public double price { get; set; }
        [Display(Name = "ID Transaccion")]
        public string transaction_id { get; set; }
        [Display(Name = "E-mail Usuario")]
        public string user_email { get; set; }
        [Display(Name = "URL de pago")]
        public string url_payment { get; set; }
        [MaxLength(20)]
        [Display(Name = "Estado Pago")]
        public string paymentStatus { get; set; }
    }
}
