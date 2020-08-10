using System;
using System.ComponentModel.DataAnnotations;

namespace PersistenceEvertecTest.Entities
{
    public class orders //POCO
    {
        [Required]
        public int id { get; set; }
        [Required]
        [StringLength(80)]
        public string customer_name { get; set; }
        [Required]
        [StringLength(120)]
        public string customer_email { get; set; }
        [Required]
        [StringLength(40)]
        public string customer_mobile { get; set; }
        [StringLength(20)]
        [MaxLength(20)]
        public string status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public double price { get; set; }
        public string transaction_id { get; set; }
        public string user_email { get; set; }
        [StringLength(100)]
        public string url_payment { get; set; }
        [MaxLength(20)]
        public string paymentStatus { get; set; }


    }
}
