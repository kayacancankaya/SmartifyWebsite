using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartifyWebsite.Data
{
	public class Product
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[MaxLength(100)]
		public string ProductCode { get; set; } 
		[Required]
		[MaxLength(100)]
		public string Name_EN { get; set; } // Name in English

		[Required]
		[MaxLength(100)]
		public string Name_ES { get; set; } // Name in Spanish

		[Required]
		[MaxLength(100)]
		public string Name_TR { get; set; } // Name in Turkish

		[MaxLength(1000)]
		public string Description_EN { get; set; } // Description in English

		[MaxLength(1000)]
		public string Description_ES { get; set; } // Description in Spanish

		[MaxLength(1000)]
		public string Description_TR { get; set; } // Description in Turkish
		[MaxLength(1000)]
		public string Keywords_EN { get; set; } // Description in English

		[MaxLength(1000)]
		public string Keywords_ES { get; set; } // Description in Spanish

		[MaxLength(1000)]
		public string Keywords_TR { get; set; } // Description in Turkish

		[Required]
		public int CategoryID { get; set; } 

		[Column(TypeName = "decimal(18,2)")]
		public decimal StandartPrice { get; set; } // Price of the product
		
		[Column(TypeName = "decimal(18,2)")]
		public decimal ActualPrice { get; set; } // Price of the product

		[MaxLength(1000)]
		public string? VideoLink { get; set; } = string.Empty;

		public bool IsActive { get; set; } = true; // Is the product active?

		[Required]
		[MaxLength(20)]
		public string? Related { get; set; } = string.Empty;

		public int Popularity { get; set; }
		public int Wished { get; set; }


		[Required]
		public DateTime CreatedAt { get; set; } = DateTime.Now;
		[Required]
		public int CreatedBy { get; set; } = 0;
		[Required]
		public DateTime EditedAt { get; set; } = DateTime.Now;
		[Required]
		public int EditedBy { get; set; } = 0;

		[ForeignKey("CategoryID")]
		public virtual ProductCategory Category { get; set; } = new();
	}
}
