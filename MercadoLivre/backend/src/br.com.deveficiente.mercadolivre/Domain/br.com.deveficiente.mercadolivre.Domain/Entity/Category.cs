namespace br.com.deveficiente.mercadolivre.Domain.Entity
{
    public class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Category() { }

        public void setName(string name)
        {
            Name = name;
        }
    }
}
