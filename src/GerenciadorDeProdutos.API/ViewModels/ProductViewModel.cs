using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;

namespace GerenciadorDeProdutos.API.ViewModels
{
    public class ProductViewModel 
    {
        [SwaggerSchema(ReadOnly = true)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set;}
        public float Price { get; set; }
        public bool Situation { get; set; }
        public List<Guid> IdsCategories { get; set; }

    }
}
