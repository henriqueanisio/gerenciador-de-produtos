using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorDeProdutos.Domain.Models
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }
        public bool Situation { get; set; }
        [NotMapped]
        public List<Category> Categories { get; set; }

        public ICollection<ProductCategory> ProductsCategories { get; set; }

    }
}
