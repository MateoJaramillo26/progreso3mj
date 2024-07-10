using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace progreso3mj.Models


{
    public class MealMJ
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string IdMeal { get; set; }
        public string StrMeal { get; set; }
        public string StrCategory { get; set; }
        public string StrArea { get; set; }
        public string StrInstructions { get; set; }
        public string StrMealThumb { get; set; }
    }
}
