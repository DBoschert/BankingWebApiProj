using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingWebApi.Models {
    public class Account {
        public int Id { get; set; }
        [StringLength(30)]
        public string Type { get; set; } = string.Empty;
        [StringLength(80)]
        public string Description { get; set; } = string.Empty;
        [Column(TypeName = "decimal(11,2)")]
        public decimal InterestRate { get; set; } = 0.01m;
        [Column(TypeName = "decimal(11,2)")]
        public decimal Balance { get; set; } = 0;
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }
        
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}
