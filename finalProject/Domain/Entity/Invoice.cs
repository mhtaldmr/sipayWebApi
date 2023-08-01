using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity;

public class Invoice
{
    public int Id { get; set;}
    public int Electricity { get; set;}
    public int Water { get; set; }
    public int NaturalGas { get; set; }
    public int CommonExpenses { get; set; }
    public Month Month { get; set; }
    public DateTime CreatedAt { get; set; }

    public int ApartmentId { get; set; }
    [ForeignKey("ApartmentId")]
    public Apartment Apartment { get; set; }

}
