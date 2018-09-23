using System.Collections.Generic;

namespace MealApplication.Domain.Base
{
    public abstract class Dish
    {
        public List<string> Entries { get; set; }
        public List<string> result = new List<string>();

        public Dish(List<string> entries)
        {
            Entries = entries;
        }

        protected abstract bool CanRepeat(int dish);
        protected abstract void BuildMeal();
        public abstract void OutputResult();
        protected abstract string CheckOption(int dish, int quantity);
    }
}
