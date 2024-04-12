namespace InvoiceAppApi.Models
{
    public class MultiplePayment_ViewModel
    {
        public ICollection<Payment> Invoice { get; set; }
        public PaymentDetails Detail { get; set; }
        public ICollection<InvoicePayment>? InvoicePayments { get; set; }
    }
}
