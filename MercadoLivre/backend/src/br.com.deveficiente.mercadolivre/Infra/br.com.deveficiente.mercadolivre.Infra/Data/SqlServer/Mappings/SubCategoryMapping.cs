namespace br.com.deveficiente.mercadolivre.Infra.Data.SqlServer.Mappings
{
    public class SubCategoryMapping : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.ToTable("SubCategory");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                  .IsRequired()
                  .HasMaxLength(255);

            builder.HasOne(sc => sc.Category)
               .WithMany(c => c.subCategory)
               .HasForeignKey(sc => sc.CategoryId)
               .OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("FK_CategoryId_Category");

            builder.Ignore(c => c.Category);


        }
    }
}
