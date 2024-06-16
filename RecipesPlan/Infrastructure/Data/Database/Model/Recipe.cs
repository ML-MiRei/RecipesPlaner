using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesPlan.Infrastructure.Data.Database.Model
{
    [Table("Recipe")]
    public class Recipe
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("recipe_id")]
        public int Id { get; set; }

        [Column("section_id")]
        public int SectionId { get; set; }

        [Column("label")]
        public string Label { get; set; }

        [Column("note")]
        public string? Note { get; set; }

        [Column("calories")]
        public double Calories { get; set; }

        [Column("portions")]
        public double Portions { get; set; }

        [Column("date")]
        public DateTime? Date { get; set; }

    }
}
