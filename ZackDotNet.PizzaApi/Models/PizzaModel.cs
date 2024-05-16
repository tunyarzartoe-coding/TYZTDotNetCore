using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZackDotNet.PizzaApi.Models
{
    [Table("Tbl_Pizza")]
    public class PizzaModel
    {
        [Key]
        [Column("PizzaId")]
        public int Id { get; set; }
        [Column("Pizza")]
        public string? Name { get; set; }
        [Column("Price")]
        public decimal Price { get; set; }
        [NotMapped]
        public string PriceStr { get { return "$" + Price; } }


    }
    //public record BlogEntity (int BlogId, string BlogTitle, string BlogAuthor, string BlogContent);
}
