using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity;

public class Message
 {
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
   
    public string SenderId  { get; set; } = string.Empty;
    [ForeignKey("SenderId")]
    public User Sender { get; set; }
 }