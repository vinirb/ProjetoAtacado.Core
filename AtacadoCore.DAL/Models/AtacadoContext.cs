using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AtacadoCore.DAL.Models
{
    public partial class AtacadoContext : DbContext
    {
        public AtacadoContext()
        {
        }

        public AtacadoContext(DbContextOptions<AtacadoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; }
        public virtual DbSet<CidadesUtf8> CidadesUtf8s { get; set; }
        public virtual DbSet<ListaMunicipiosIbgeBrasilUtf8> ListaMunicipiosIbgeBrasilUtf8s { get; set; }
        public virtual DbSet<Mesoregiao> Mesoregiaos { get; set; }
        public virtual DbSet<Microregiao> Microregiaos { get; set; }
        public virtual DbSet<Municipio> Municipios { get; set; }
        public virtual DbSet<MunicipiosComplementarIbgeUtf8> MunicipiosComplementarIbgeUtf8s { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Regiao> Regiaos { get; set; }
        public virtual DbSet<Subcategorium> Subcategoria { get; set; }
        public virtual DbSet<Teste> Testes { get; set; }
        public virtual DbSet<UnidadesFederacao> UnidadesFederacaos { get; set; }
        public virtual DbSet<VwcapacitacaoModelo01> VwcapacitacaoModelo01s { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=LAB04\\SQLEXPRESS;Database=CapacitacaoPSG2021H2;Trusted_Connection=True");
                throw new ArgumentException("String de conexão não foi carregada adequadamente");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.Catid)
                    .HasName("pk_categoria");

                entity.Property(e => e.Datainsert).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Descricao).IsUnicode(false);
            });

            modelBuilder.Entity<CidadesUtf8>(entity =>
            {
                entity.Property(e => e.Ibge).ValueGeneratedNever();
            });

            modelBuilder.Entity<ListaMunicipiosIbgeBrasilUtf8>(entity =>
            {
                entity.Property(e => e.Ibge7).ValueGeneratedNever();
            });

            modelBuilder.Entity<Mesoregiao>(entity =>
            {
                entity.Property(e => e.Datainsert).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Descricao).IsUnicode(false);

                entity.HasOne(d => d.Uf)
                    .WithMany(p => p.Mesoregiaos)
                    .HasForeignKey(d => d.Ufid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mesoregiao_UnidadesFederacao");
            });

            modelBuilder.Entity<Microregiao>(entity =>
            {
                entity.Property(e => e.Datainsert).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Descricao).IsUnicode(false);

                entity.HasOne(d => d.Mesoregiao)
                    .WithMany(p => p.Microregiaos)
                    .HasForeignKey(d => d.MesoregiaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Microregiao_Mesoregiao");
            });

            modelBuilder.Entity<Municipio>(entity =>
            {
                entity.Property(e => e.Descricao).IsUnicode(false);

                entity.Property(e => e.SiglaUf)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Mesoregiao)
                    .WithMany(p => p.Municipios)
                    .HasForeignKey(d => d.MesoregiaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Municipio_Mesoregiao");

                entity.HasOne(d => d.Microregiao)
                    .WithMany(p => p.Municipios)
                    .HasForeignKey(d => d.MicroregiaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Municipio_Microregiao");

                entity.HasOne(d => d.Uf)
                    .WithMany(p => p.Municipios)
                    .HasForeignKey(d => d.Ufid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Municipio_UnidadesFederacao");
            });

            modelBuilder.Entity<MunicipiosComplementarIbgeUtf8>(entity =>
            {
                entity.Property(e => e.MunicipioId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.Property(e => e.Datainsert).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Descricao).IsUnicode(false);

                entity.HasOne(d => d.Subcat)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.Subcatid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_produto_subcategoria");
            });

            modelBuilder.Entity<Regiao>(entity =>
            {
                entity.Property(e => e.Datainsert).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Descricao).IsUnicode(false);

                entity.Property(e => e.SiglaRegiao)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Subcategorium>(entity =>
            {
                entity.HasKey(e => e.Subcatid)
                    .HasName("pk_subcategoria");

                entity.Property(e => e.Datainsert).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Descricao).IsUnicode(false);

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Subcategoria)
                    .HasForeignKey(d => d.Catid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_subcategoria_categoria");
            });

            modelBuilder.Entity<Teste>(entity =>
            {
                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Endereco).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.Property(e => e.Telefone).IsUnicode(false);
            });

            modelBuilder.Entity<UnidadesFederacao>(entity =>
            {
                entity.Property(e => e.Datainsert).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Descricao).IsUnicode(false);

                entity.Property(e => e.SiglaUf)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Regiao)
                    .WithMany(p => p.UnidadesFederacaos)
                    .HasForeignKey(d => d.RegiaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UnidadesFederacao_Regiao");
            });

            modelBuilder.Entity<VwcapacitacaoModelo01>(entity =>
            {
                entity.ToView("VWCapacitacaoModelo01");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
