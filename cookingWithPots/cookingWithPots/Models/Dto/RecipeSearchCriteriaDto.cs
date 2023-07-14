using cookingWithPots.Models.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace cookingWithPots.Models.Dto
{
    public class RecipeSearchCriteriaDto
    {
        public string SearchTerms { get; set; }
        public bool? SlowCooker { get; set; }
    }
}
