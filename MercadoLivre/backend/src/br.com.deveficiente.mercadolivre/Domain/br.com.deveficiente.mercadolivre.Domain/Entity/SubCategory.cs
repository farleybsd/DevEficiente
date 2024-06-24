namespace br.com.deveficiente.mercadolivre.Domain.Entity
{
    public class SubCategory
    {
        public int CategoryId { get; private set; }
        public int Id { get; private set; }
        public string Name { get; set; }

        public SubCategory()
        {
        }

        public void setCategoriaId(int id)
        {
            CategoryId = id;
        }

        public void setName(string name)
        {
            Name = name;
        }
    }
}