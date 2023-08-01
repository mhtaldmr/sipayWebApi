using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Entity;

public class Apartment
{
    public int Id { get; set; }
    public string BlockName { get; set; } = string.Empty;
    public bool IsAvaliable { get; set; } = true;
    public int Floor { get; set; }
    public int Flat { get; set; }
    public bool IsRental { get; set; }
    public int Balance { get; set; }
    public Invoice Invoice { get; set; }
    public FlatType FlatType { get; set; }

    public string UserId { get; set; } = string.Empty;
    [ForeignKey("UserId")]
    public User User { get; set; }
}