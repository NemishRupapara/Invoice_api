namespace InvoiceAppApi.Models
{
    public class InvoiceClass
    {
        
        public int? InvoiceID { get; set; }
        public int? InvoiceNo { get; set; }
        public string? CustomerName { get; set; }
        public string? GSTNo { get; set; }
        public string? BillDate { get; set; }
        public string? DueDate { get; set; }
        public int? RemainingDays { get; set; }
        public int? Totalitem { get; set; }
        public int? TotalAmount { get; set; }
        public int? UserID { get; set; }
        public string? UserName { get; set; }
        public int? PaidAmount { get; set; }
        public int? RemainingAmount { get; set; }

    }
}
