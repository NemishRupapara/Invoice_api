using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceAppApi.Models
{
    public class Class1
    {
        public int ID { get; set; }
        public string Item { get; set; }
        public int Quantity { get; set; }
        public int Rate { get; set; }
        public int Amount { get; set; }


        [ForeignKey("InvoiceID")]

        public int InvoiceID { get; set; }
    }
}
