using Swashbuckle.AspNetCore.Annotations;

namespace GerenciadorDeProdutos.API.ViewModels
{
    public class CategoryViewModel 
    {
        [SwaggerSchema(ReadOnly = true)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Situation { get; set; }
    }
}
