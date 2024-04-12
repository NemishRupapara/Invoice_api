namespace InvoiceAppApi.Models
{
    public class Payment
    {
        public int? InvoiceID { get; set; }
        public int? InvoiceNo { get; set; }
     
        public int? TotalAmount { get; set; }
    
        public int? PaidAmount { get; set; }
        public int? RemainingAmount { get; set; }
    }
}
