using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;


namespace ECommerceApp.Models;

using System.ComponentModel.DataAnnotations;
    
[Table("Category")]
public class Category
{
    [Key] public int Id { get; set; }
    
    [DisplayName("Category Name")]
    [MaxLength(30)]
    [Required] public string  Name { get; set; }
    
    [DisplayName("Display Order")]
    [Range(1,100,ErrorMessage = "Display order must be between 1-100 ")]
    public int DisplayOrder { get; set; }
}