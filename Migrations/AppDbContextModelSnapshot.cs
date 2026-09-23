using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using projetoAPI.Data;

#nullable disable

namespace projetoAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("projetoAPI.Models.Categoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_categoria");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdCategoria"));

                    b.Property<string>("Descricao")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("descricao");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nome");

                    b.HasKey("IdCategoria");

                    b.ToTable("categorias");
                });

            modelBuilder.Entity("projetoAPI.Models.Produto", b =>
                {
                    b.Property<int>("IdProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_produto");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdProduto"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("ativo");

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("atualizado_em");

                    b.Property<int?>("CategoriaId")
                        .HasColumnType("int")
                        .HasColumnName("categoria_id");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("criado_em");

                    b.Property<string>("Descricao")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("descricao");

                    b.Property<int>("Estoque")
                        .HasColumnType("int")
                        .HasColumnName("estoque");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("nome");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("preco");

                    b.HasKey("IdProduto");

                    b.ToTable("produtos");
                });

            modelBuilder.Entity("projetoAPI.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_usuario");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("email");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("senha");

                    b.HasKey("IdUsuario");

                    b.ToTable("usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
