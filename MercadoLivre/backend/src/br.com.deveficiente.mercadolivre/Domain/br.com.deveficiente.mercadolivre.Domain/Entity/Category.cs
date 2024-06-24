namespace br.com.deveficiente.mercadolivre.Domain.Entity
{
    public class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public int IdCategory { get; private set; }

        public virtual ICollection<SubCategory> subCategory { get; private set; }

        public Category() { }

        public void setName(string name)
        {
            Name = name;
        }

        public void setIdCategory(int idCategory)
        {
            IdCategory = idCategory;
        }
    }
}
