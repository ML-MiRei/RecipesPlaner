using SQLite;

namespace RecipesPlan.Infrastructure.Data.Database.Model
{

    [Table("Ingredients")]
    public class Ingredient
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("ingredient_id")]
        public int Id { get; set; }

        [Column("line")]
        public string Line {  get; set; }
        
        [Column("recipe_Id")]
        public int RecipeId {  get; set; }

    }
}
