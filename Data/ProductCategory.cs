using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartifyWebsite.Data
{
	public class ProductCategory
	{

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Required]
		[MaxLength(100)]
		public string CategoryName_EN { get; set; } 
		[Required]
		[MaxLength(100)]
		public string CategoryName_ES { get; set; } 
		[Required]
		[MaxLength(100)]
		public string CategoryName_TR { get; set; }
		public ICollection<Product> Products { get; set; } = new List<Product>();
	}
}
