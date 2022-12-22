using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeProdutos.Web.ViewModels
{
    public class BaseViewModel
    {
        [Key]
        public Guid Id { get; set; }
    }
}
