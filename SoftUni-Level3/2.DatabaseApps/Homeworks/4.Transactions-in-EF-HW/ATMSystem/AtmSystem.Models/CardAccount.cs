namespace ATMSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;

    public class CardAccount
    {
        public CardAccount()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(10)]
        public string CardNumber { get; set; }

        [StringLength(4)]
        public string CardPin { get; set; }

        public decimal CardCash { get; set; }
    }
}