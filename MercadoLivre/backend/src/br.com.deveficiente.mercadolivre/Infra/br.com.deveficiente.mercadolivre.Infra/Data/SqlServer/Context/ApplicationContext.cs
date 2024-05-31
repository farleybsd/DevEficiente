namespace br.com.deveficiente.mercadolivre.Infra.Data.SqlServer.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Login> Login { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LoginMapping());
            // Aqui você pode adicionar outros mapeamentos
        }
    }
}