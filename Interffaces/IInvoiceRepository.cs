using InvoiceAppApi.Dto;
using InvoiceAppApi.Models;

namespace InvoiceAppApi.Interffaces
{
    public interface IInvoiceRepository
    {
        bool AddInvoice(InvoiceDto Invoice);

        ICollection<InvoiceClass> GetInvoiceList(int UserID);
        ICollection<InvoiceClass> GetAllInvoiceList();

        ICollection<PaymentDetails> GetAllPaymentDetailsList(int userId);
        InvoiceClass GetSinglePaymentdetail(int InvoiceID);
        ICollection<InvoiceClass> GetInvoiceListOfCustomer(CustomerPayment Customer);
        ICollection<InvoicePayment> GetInvoicePaymentForEdit(int PaymentID);

       PaymentDetails GetPaymentDetailForEdit(int ID);



        InvoiceDto GetEditInvoiceDetail(int InvID);

        bool EditInvoice(InvoiceDto Invoice);
        bool EditSinglePayment(Payment payment);

        bool EditMultiplePayment(MultiplePayment_ViewModel viewModel);

        bool EditPaymentDetails(MultiplePayment_ViewModel viewModel);

        bool DeleteInvoice(int InvID);
        bool DeletePayment(int paymentID);
    }
}
