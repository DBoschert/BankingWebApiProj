using BankingWebApi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingWebApiProj.Models
{
    public class Transaction
    {

        public int Id { get; set; }
        public int AccountId { get; set; }
        public virtual Account? Account { get; set; }
        
        [Column(TypeName = "decimal(11,2)")]
        public decimal PreviousBalance { get; set; }
        [StringLength(1)]
        public string TransactionType { get; set; } = string.Empty;
        [Column(TypeName = "decimal(11,2)")]
        public decimal NewBalance { get; set; }
        [StringLength(80)]
        public string Description { get; set; } = string.Empty;
        [Column(TypeName = "DateTime")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;


    }
}
