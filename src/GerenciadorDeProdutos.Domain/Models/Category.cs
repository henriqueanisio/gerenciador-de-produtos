namespace GerenciadorDeProdutos.Domain.Models
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public bool Situation { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }

    }
}
