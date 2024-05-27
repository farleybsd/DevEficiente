using br.com.deveficiente.mercadolivre.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace br.com.deveficiente.mercadolivre.Infra.Data.SqlServer.Mappings
{
    public class LoginMapping : IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> builder)
        {
            builder.ToTable("Login");

            builder.HasKey(x => x.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            // Mapeamento para Instant
            builder.OwnsOne(l => l.Instant, i =>
            {
                i.Property(p => p.CreationDate).HasColumnName("Instant").IsRequired();
            });

            // Mapeamento para Email
            builder.OwnsOne(l => l.Email, e =>
            {
                e.Property(p => p.Address).HasColumnName("Email").IsRequired();
            });

            // Mapeamento para Password
            builder.OwnsOne(l => l.Password, p =>
            {
                p.Property(pp => pp.EncryptedPassword).HasColumnName("Password").IsRequired();
            });
        }
    }
}

