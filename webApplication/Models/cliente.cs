namespace webApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cliente")]
    public partial class cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cliente()
        {
            acesso = new HashSet<acesso>();
            contato = new HashSet<contato>();
        }

        [Key]
        public int idCliente { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nome")]
        public string nomeCliente { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "CNPJ")]
        public string cnpjCliente { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Unidade")]
        public string unidade { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Endereço")]
        public string enderecoFisico { get; set; }

        [StringLength(20)]
        [Display(Name = "Telefone")]
        public string telefone { get; set; }

        [StringLength(100)]
        [Display(Name = "Endereco Eletronico")]
        public string enderecoEletronico { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<acesso> acesso { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<contato> contato { get; set; }
    }
}
