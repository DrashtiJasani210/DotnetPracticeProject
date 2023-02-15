using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage="Category Name is Required")]
        [Display(Name ="Category Name")]
        public String Name { get; set; }

        [Display(Name = "Display Order")]
        public int DisplayOrder { get; set; }

        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; } = DateTime.Now;
    }
}
