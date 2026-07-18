using SplitWise.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SplitWise.Infrastructure.Data.Configurations;


public class GrupoConfiguration : IEntityTypeConfiguration<Grupo>
{
    public void Configure(EntityTypeBuilder<Grupo> builder)
    {
        builder.ToTable("grupos");
        builder.HasKey(g => g.Id);
        builder.Property(g => g.Nome).HasMaxLength(100).IsRequired();
        builder.Property(g => g.DataCriacao).IsRequired();
    }
}