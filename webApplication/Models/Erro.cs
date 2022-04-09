
namespace webApplication.Models {
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.ComponentModel.DataAnnotations;
	using System.Linq;
	using System.Web;

	[Table("Erro")]
	public class Erro {
		[Key]
		public int IdErro { get; set; }

		
		[StringLength(500)]
		[Display(Name = "Origem do Erro", Description = "caminho que mostra onde/linha que o erro aconteceu dentro do sistema")]
		public string Stack { get; set; }

		[StringLength(200)]
		[Display(Name = "Tipo do Erro")]
		public string Type { get; set; }

		[Required]
		[StringLength(500)]
		[Display(Name = "Mensagem de Erro", Description = "Mensagem genérica demonstrada pela Exception lançada")]
		public string Message { get; set; }

		[StringLength(1000)]
		[Display(Name = "Trace", Description = "todo o erro apresentado no log ou tela")]
		public string Trace { get; set; }

		[Display(Name = "Resolvido?")]
		public bool Done { get; set; }

		[StringLength(2000)]
		[Display(Name ="Como Solucionar")]
		public string Solution { get; set; }
	}
}