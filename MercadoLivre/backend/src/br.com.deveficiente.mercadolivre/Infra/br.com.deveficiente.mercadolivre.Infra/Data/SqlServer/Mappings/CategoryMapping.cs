﻿namespace br.com.deveficiente.mercadolivre.Infra.Data.SqlServer.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categoria");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.HasIndex(c => c.Name)
              .IsUnique();
        }
    }
}
