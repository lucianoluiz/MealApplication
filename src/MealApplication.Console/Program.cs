using MealApplication.Domain.Services;
using Common = System.Console;

namespace MealApplication.Console
{
    public class Program
    {
        public static void Main()
        {
            Common.WriteLine("Please, enter your dishes");
            var entry = Common.ReadLine();

            Execution.Execute(entry);
            Common.ReadKey();
        }
    }
}
