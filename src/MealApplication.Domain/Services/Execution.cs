namespace MealApplication.Domain.Services
{
    public class Execution
    {
        public static void Execute(string entry)
        {
            var orderDish = new MakeDish(entry);

            var dish = orderDish.GetDish();

            if (dish == null)
                System.Console.WriteLine("invalid period.");
            else
                dish.OutputResult();
        }
    }
}
