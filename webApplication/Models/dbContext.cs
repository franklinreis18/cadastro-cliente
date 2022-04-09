namespace webApplication.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class dbContext : DbContext
    {
        public dbContext()
            : base("name=dbContext")
        {
        }

        public virtual DbSet<acesso> acesso { get; set; }
        public virtual DbSet<cliente> cliente { get; set; }
        public virtual DbSet<contato> contato { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<acesso>()
                .Property(e => e.tipoAcesso)
                .IsUnicode(false);

            modelBuilder.Entity<acesso>()
                .Property(e => e.hostAcesso)
                .IsUnicode(false);

            modelBuilder.Entity<acesso>()
                .Property(e => e.usuarioAcesso)
                .IsUnicode(false);

            modelBuilder.Entity<acesso>()
                .Property(e => e.senhaAcesso)
                .IsUnicode(false);

            modelBuilder.Entity<acesso>()
                .Property(e => e.obsAcesso)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.nomeCliente)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.cnpjCliente)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.unidade)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.enderecoFisico)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.telefone)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.enderecoEletronico)
                .IsUnicode(false);

            modelBuilder.Entity<contato>()
                .Property(e => e.nomeContato)
                .IsUnicode(false);

            modelBuilder.Entity<contato>()
                .Property(e => e.setorContato)
                .IsUnicode(false);

            modelBuilder.Entity<contato>()
                .Property(e => e.telefoneContato)
                .IsUnicode(false);

            modelBuilder.Entity<contato>()
                .Property(e => e.emailContato)
                .IsUnicode(false);
            modelBuilder.Entity<Erro>()
                .Property(e => e.Message)
                .IsUnicode(false);
            modelBuilder.Entity<Erro>()
               .Property(e => e.Stack)
               .IsUnicode(false);
            modelBuilder.Entity<Erro>()
               .Property(e => e.Trace)
               .IsUnicode(false);
            modelBuilder.Entity<Erro>()
               .Property(e => e.Type)
               .IsUnicode(false);
            modelBuilder.Entity<Erro>()
               .Property(e => e.Solution)
               .IsUnicode(false);
        }

		public virtual DbSet<Erro> Erroes { get; set; }
	}
}
