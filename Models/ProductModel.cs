using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace MVC.Models;
[Table("Món ăn")]
public class ProductModel
{
    [Key]
    [Column("Mã món ăn")]
    public int ProId { set; get; }
    [StringLength(50)]
    [Column("Tên món ăn")]
    public string? Name { set; get; }
    [StringLength(1000)]
    [Column("Mô tả")]
    public string? Description { set; get; }
    [Column("Giá")]
    public decimal Price { get; set; }
    [Column("Danh mục")]
    public int CateId { get; set; }
    //Foreign key
    [ForeignKey("CateId")]
    //[Required]
    public virtual CategoryModel Category { get; set; }
}