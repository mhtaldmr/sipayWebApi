using Domain.Entity;

namespace Application.Dtos.Invoices;

public class InvoiceDto
{
    public int Electricity { get; set;}
    public int Water { get; set; }
    public int NaturalGas { get; set; }
    public int CommonExpenses { get; set; }
    public Month Month { get; set; }
    public int ApartmentId { get; set; }
}