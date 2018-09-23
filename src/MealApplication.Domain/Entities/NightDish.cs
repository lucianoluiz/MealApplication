using MealApplication.Domain.Base;
using MealApplication.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MealApplication.Domain.Entities
{
    public class NightDish : Dish
    {
        public NightDish(List<string> entries)
            : base(entries)
        {
        }

        public override void OutputResult()
        {
            BuildMeal();
            var formatOutput = string.Join(", ", result.ToArray());

            if (string.IsNullOrEmpty(formatOutput))
                System.Console.WriteLine($"Output: None dish was input");
            else
                System.Console.WriteLine($"Output: {formatOutput}");
        }

        protected override void BuildMeal()
        {
            var numberDishes = Entries.Where(p => p.ToUpper() != "NIGHT").OrderBy(p => p).ToList();
            var numberDishesRepeated = numberDishes.Where(p => !string.IsNullOrEmpty(p)).GroupBy(p => p).Select(p => new { Dish = Convert.ToInt32(p.Key), Count = p.Count() });

            foreach (var selectedDish in numberDishesRepeated)
            {
                var output = CheckOption(selectedDish.Dish, selectedDish.Count);

                if (!result.Contains(output))
                    result.Add(output);
            }
        }

        protected override bool CanRepeat(int dish)
        {
            return dish == (int)NightDishesEnum.Potato;
        }

        protected override string CheckOption(int dish, int quantity)
        {
            switch (dish)
            {
                case (int)NightDishesEnum.Steak:
                    return "steak";

                case (int)NightDishesEnum.Potato:
                    if (CanRepeat(dish) && quantity > 1)
                        return $"potato(x{quantity})";
                    else
                        return "potato";

                case (int)NightDishesEnum.Wine:
                    return "wine";

                case (int)NightDishesEnum.Cake:
                    return "cake";

                default:
                    return "error";
            }
        }
    }
}
