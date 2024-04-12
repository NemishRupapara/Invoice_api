namespace InvoiceAppApi.Models
{
    public class InvoicePayment
    {
        public int ID { get; set; } 
        public int PaymentID {  get; set; }
        public int? InvoiceID { get; set; }
        public int? InvoiceNo { get; set; }
        public string? CustomerName {  get; set; }

        public int? TotalAmount { get; set; }

        public int? PaidAmount { get; set; }
        public int? RemainingAmount { get; set; }

        
        public int SinglePaidAmount { get;set;}
        public int LeftAmount { get; set; }



    }
}
