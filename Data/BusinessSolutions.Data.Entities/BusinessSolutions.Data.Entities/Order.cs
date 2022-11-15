using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace BusinessSolutions.Data.Entities
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Number { get; set; } = string.Empty;
        //[Column(TypeName = "date")]
        public DateTime Date { get; set; }
        public int? ProviderId { get; set; }
        public virtual ICollection<OrderItem> Items { get; set; }
        public virtual Provider Provider { get; set; }
    }
}
