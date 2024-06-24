namespace br.com.deveficiente.mercadolivre.Infra.Data.SqlServer.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Login> Login { get; set; }
        public DbSet<Category> Category { get; set; }

        public DbSet<SubCategory> SubCategory { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LoginMapping());
            modelBuilder.ApplyConfiguration(new CategoryMapping());
            modelBuilder.ApplyConfiguration(new SubCategoryMapping());
            // Aqui você pode adicionar outros mapeamentos
        }
    }
}