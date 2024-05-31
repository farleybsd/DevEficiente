namespace br.com.deveficiente.mercadolivre.Infra.Data.SqlServer.Mappings
{
    public class LoginMapping : IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> builder)
        {
            builder.ToTable("Login");

            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Email)
                .Property(x => x.Address)
                .HasColumnName("Email")
                .IsRequired(true);

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