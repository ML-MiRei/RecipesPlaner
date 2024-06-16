using SQLite;

namespace RecipesPlan.Infrastructure.Data.Database.Model
{
    [Table("Menu")]
    public class Menu
    {
        [PrimaryKey]
        [Column("menu_id")]
        public int Id { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }
        
        [Column("recipe_Id")]
        public int RecipeId {  get; set; }

    }
}
