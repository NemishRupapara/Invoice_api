namespace InvoiceAppApi.Models
{
    public class PaymentDetails
    {
        public int ID { get; set; }
        public string? CustomerName { get; set; }
        public string? PaymentMode { get; set; }
        public string? ReferenceNo { get; set; }
        public string? PaymentDate { get; set; }
        public string? ChequeDate { get; set; }
        public string? BankName { get; set; }
        public int Amount { get; set; }

     


    }
}
