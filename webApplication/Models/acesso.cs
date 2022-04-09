namespace webApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("acesso")]
    public partial class acesso
    {
        [Key]
        public int idAcesso { get; set; }
        [Display(Name = "Cliente")]
        public int? idCliente { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Tipo de Acesso")]
        public string tipoAcesso { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Host de Acesso")]
        public string hostAcesso { get; set; }

        [StringLength(50)]
        [Display(Name = "Usuário")]
        public string usuarioAcesso { get; set; }

        [StringLength(50)]
        [Display(Name = "Senha de Acesso")]
        public string senhaAcesso { get; set; }

        [StringLength(200)]
        [Display(Name = "Observação")]
        public string obsAcesso { get; set; }

        public virtual cliente cliente { get; set; }
    }
}
