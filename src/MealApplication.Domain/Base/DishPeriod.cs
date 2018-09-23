using System.Collections.Generic;
using System.Linq;

namespace MealApplication.Domain.Base
{
    public abstract class DishPeriod
    {
        public List<string> Entries { get; set; }

        public DishPeriod(string entry)
        {
            var arrayEntry = entry.Split(',').ToList();
            Entries = arrayEntry;
        }

        public abstract Dish GetDish();
    }
}
