using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace MVC.Models;
[Table("Liên hệ")]
public class ContactModel
{
    [Key]
    [Column("MaLH")]
    public int ConId { set; get; }
    [Column("TenKH")]
    [StringLength(50)]
    public string? CustomerName { set; get; }
    [StringLength(100)]
    public string? Email { set; get; }
}