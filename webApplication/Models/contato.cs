namespace webApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("contato")]
    public partial class contato
    {
        [Key]
        public int idContato { get; set; }
        [Display(Name = "Cliente")]
        public int? idCliente { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nome do Contato")]
        public string nomeContato { get; set; }

        [StringLength(50)]
        [Display(Name = "Setor de Atuação")]
        public string setorContato { get; set; }

        [StringLength(50)]
        [Display(Name = "Telefone")]
        public string telefoneContato { get; set; }

        [StringLength(50)]
        [Display(Name = "Email")]
        public string emailContato { get; set; }

        public virtual cliente cliente { get; set; }
    }
}
