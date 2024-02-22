using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BookStoreRazorWeb_Temp.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(35)]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(0, 100)]
        public int DisplayOrder { get; set; }
    }
}
