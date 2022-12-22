using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeProdutos.Web.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        [DisplayName("Nome")]
        public string Name { get; set; }
        [DisplayName("Descrição")]
        public string? Description { get; set;}
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Preço")]
        public float Price { get; set; }
        [DisplayName("Situação")]
        public bool Situation { get; set; }

        public List<Guid> IdsCategories { get; set; }

        [DisplayName("Categorias")]
        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
