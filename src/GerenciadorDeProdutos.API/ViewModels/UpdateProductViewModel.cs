namespace GerenciadorDeProdutos.API.ViewModels
{
    public class UpdateProductViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set;}
        public float Price { get; set; }
        public bool Situation { get; set; }
        public List<Guid> IdsCategories { get; set; }

    }
}
