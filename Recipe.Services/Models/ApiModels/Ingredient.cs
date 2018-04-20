namespace Recipe.Services.Models.ApiModels
{
    public class Ingredient
    {
        public string IngredientName { get; set; }
        public int IngredientId { get; set; }
        public string Unit { get; set; }
        public string Quantity { get; set; }
        public bool MainIngredient { get; set; }
    }
}
