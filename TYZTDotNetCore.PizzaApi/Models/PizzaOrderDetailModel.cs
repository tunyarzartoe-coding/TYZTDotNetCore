using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYZTDotNetCore.PizzaApi.Models
{
    [Table("Tbl_PizzaOrderDetail")]
    public class PizzaOrderDetailModel
    {
        [Key]
        public int PizzaOrderDetailId { get; set; }
        public string PizzaOrderInvoiceNo { get; set; }
        public int PizzaExtraId { get; set; }
    }
}
