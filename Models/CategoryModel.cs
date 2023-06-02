using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace MVC.Models;
[Table("Danh mục")]
public class CategoryModel
{
    [Key]
    [Column("Mã danh mục")]
    public int CateId { set; get; }
    [Column("Tên danh mục")]
    public string? Name { set; get; }
}