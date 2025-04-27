using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartifyWebsite.Data
{
	public class PricingList
	{
		[Required]
		public string ProductCode { get; set; }
		[Required]
		[MaxLength(100)]
		public string Plan1_EN { get; set; } 

		[Required]
		[MaxLength(100)]
		public string Plan1_ES { get; set; } 

		[Required]
		[MaxLength(100)]
		public string Plan1_TR { get; set; } 
		[Required]
		[MaxLength(100)]
		public string Plan2_EN { get; set; } 

		[Required]
		[MaxLength(100)]
		public string Plan2_ES { get; set; } 

		[Required]
		[MaxLength(100)]
		public string Plan2_TR { get; set; } 
		[Required]
		[MaxLength(100)]
		public string Plan3_EN { get; set; } 

		[Required]
		[MaxLength(100)]
		public string Plan3_ES { get; set; } 

		[Required]
		[MaxLength(100)]
		public string Plan3_TR { get; set; } 
		[Required]
		[MaxLength(100)]
		public string Plan1Sub_EN { get; set; } 

		[Required]
		[MaxLength(100)]
		public string Plan1Sub_ES { get; set; } 

		[Required]
		[MaxLength(100)]
		public string Plan1Sub_TR { get; set; } 
		[Required]
		[MaxLength(100)]
		public string Plan2Sub_EN { get; set; } 

		[Required]
		[MaxLength(100)]
		public string Plan2Sub_ES { get; set; } 

		[Required]
		[MaxLength(100)]
		public string Plan2Sub_TR { get; set; } 
		[Required]
		[MaxLength(100)]
		public string Plan3Sub_EN { get; set; } 

		[Required]
		[MaxLength(100)]
		public string Plan3Sub_ES { get; set; } 

		[Required]
		[MaxLength(100)]
		public string Plan3Sub_TR { get; set; } 

		[MaxLength(400)]
		public string? Spec_EN_1 { get; set; } 
		[MaxLength(400)]
		public string? Spec_ES_1 { get; set; } 
		[MaxLength(400)]
		public string? Spec_TR_1 { get; set; } 
		[MaxLength(400)]
		public string? Spec_EN_2 { get; set; } 
		[MaxLength(400)]
		public string? Spec_ES_2 { get; set; } 
		[MaxLength(400)]
		public string? Spec_TR_2 { get; set; } 
		[MaxLength(400)]
		public string? Spec_EN_3 { get; set; } 
		[MaxLength(400)]
		public string? Spec_ES_4 { get; set; } 
		[MaxLength(400)]
		public string? Spec_TR_5 { get; set; } 
		[MaxLength(400)]
		public string? Spec_EN_6 { get; set; } 
		[MaxLength(400)]
		public string? Spec_ES_6 { get; set; } 
		[MaxLength(400)]
		public string? Spec_TR_6 { get; set; } 
		[MaxLength(400)]
		public string? Spec_EN_7 { get; set; } 
		[MaxLength(400)]
		public string? Spec_ES_7 { get; set; } 
		[MaxLength(400)]
		public string? Spec_TR_7 { get; set; } 
		[MaxLength(400)]
		public string? Spec_EN_8 { get; set; } 
		[MaxLength(400)]
		public string? Spec_ES_8 { get; set; } 
		[MaxLength(400)]
		public string? Spec_TR_8 { get; set; } 
		[MaxLength(400)]
		public string? Spec_EN_9 { get; set; } 
		[MaxLength(400)]
		public string? Spec_ES_9 { get; set; } 
		[MaxLength(400)]
		public string? Spec_TR_9 { get; set; } 
		[MaxLength(400)]
		public string? Spec_EN_10 { get; set; } 
		[MaxLength(400)]
		public string? Spec_ES_10 { get; set; } 
		[MaxLength(400)]
		public string? Spec_TR_10 { get; set; }

        public bool? ExistsSpec_Basic1 { get; set; }
        public bool? ExistsSpec_Basic2 { get; set; }
        public bool? ExistsSpec_Basic3 { get; set; }
        public bool? ExistsSpec_Basic4 { get; set; }
        public bool? ExistsSpec_Basic5 { get; set; }
        public bool? ExistsSpec_Basic6 { get; set; }
        public bool? ExistsSpec_Basic7 { get; set; }
        public bool? ExistsSpec_Basic8 { get; set; }
        public bool? ExistsSpec_Basic9 { get; set; }
        public bool? ExistsSpec_Basic10 { get; set; }
        public bool? ExistsSpec_Standart1 { get; set; }
        public bool? ExistsSpec_Standart2 { get; set; }
        public bool? ExistsSpec_Standart3 { get; set; }
        public bool? ExistsSpec_Standart4 { get; set; }
        public bool? ExistsSpec_Standart5 { get; set; }
        public bool? ExistsSpec_Standart6 { get; set; }
        public bool? ExistsSpec_Standart7 { get; set; }
        public bool? ExistsSpec_Standart8 { get; set; }
        public bool? ExistsSpec_Standart9 { get; set; }
        public bool? ExistsSpec_Standart10 { get; set; }
        public bool? ExistsSpec_Premium1 { get; set; }
        public bool? ExistsSpec_Premium2 { get; set; }
        public bool? ExistsSpec_Premium3 { get; set; }
        public bool? ExistsSpec_Premium4 { get; set; }
        public bool? ExistsSpec_Premium5 { get; set; }
        public bool? ExistsSpec_Premium6 { get; set; }
        public bool? ExistsSpec_Premium7 { get; set; }
        public bool? ExistsSpec_Premium8 { get; set; }
        public bool? ExistsSpec_Premium9 { get; set; }
        public bool? ExistsSpec_Premium10 { get; set; }


		[Column(TypeName = "decimal(18,2)")]
		public decimal ListPriceBasic { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public decimal ActualPriceBasic { get; set; } 

		[Column(TypeName = "decimal(18,2)")]
		public decimal ListPriceStandart { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public decimal ActualPriceStandart { get; set; } 

		[Column(TypeName = "decimal(18,2)")]
		public decimal ListPricePremium { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public decimal ActualPricePremium { get; set; } 


	}

}
