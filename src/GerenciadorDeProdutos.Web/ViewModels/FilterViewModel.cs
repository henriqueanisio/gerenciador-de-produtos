using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeProdutos.Web.ViewModels
{
    public class FilterViewModel 
    {
        public string SearchString { get; set; }
        public List<Guid> IdsCategories { get; set; }
        public string Situation { get; set; }
    }
}
