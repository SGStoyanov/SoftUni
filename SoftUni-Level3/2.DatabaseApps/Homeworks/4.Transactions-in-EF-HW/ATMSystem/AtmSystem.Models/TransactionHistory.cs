using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TransactionHistory")]
    public class TransactionHistory
    {
        public TransactionHistory()
        {
        }

        [Key]
        public int Id { get; set; }

        [StringLength(10)]
        [Required]
        public string CardNumber { get; set; }

        [Required]
        public DateTime TranscationDate { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}