using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeProdutos.Web.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Nome")]
        public string Name { get; set; }
        [DisplayName("Situação")]
        public bool Situation { get; set; }
    }
}
