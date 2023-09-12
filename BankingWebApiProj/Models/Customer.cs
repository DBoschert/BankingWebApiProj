using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingWebApi.Models
{
    [Index("CardCode", IsUnique = true)]
    public class Customer
    {

        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        public int CardCode { get; set; }
        public int PinCode { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime LastTransactionDate { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Column(TypeName = "DateTime")]
        public DateTime? ModifiedDate { get; set; }

    }
}
