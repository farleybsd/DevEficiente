namespace br.com.deveficiente.mercadolivre.Infra.Data.SqlServer.Mappings
{
    public class LoginMapping : IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> builder)
        {
            builder.ToTable("Login");

            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Email, a =>
            {
                a.Property(e => e.Address)
                    .HasColumnName("Email")
                    .IsRequired(true);

                // Adicionando o índice único para o campo Email
                a.HasIndex(e => e.Address).IsUnique();
            });

            builder.OwnsOne(x => x.Instant)
               .Property(x => x.CreationDate)
               .HasColumnName("Instant")
               .IsRequired(true);

            builder.OwnsOne(x => x.Password)
               .Property(x => x.EncryptedPassword)
               .HasColumnName("Password")
               .IsRequired(true);
        }
    }
}