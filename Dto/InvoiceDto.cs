using InvoiceAppApi.Models;

namespace InvoiceAppApi.Dto
{
    public class InvoiceDto
    {
        public InvoiceClass? Invoice { get; set; }
        public ICollection<Class1>? Item { get; set; }
    }
}
