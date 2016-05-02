using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using AtTheMovies.Services;

namespace AtTheMovies.Migrations
{
    [DbContext(typeof(MovieDb))]
    [Migration("20160502131538_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AtTheMovies.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Length");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 80);

                    b.HasKey("Id");
                });
        }
    }
}
