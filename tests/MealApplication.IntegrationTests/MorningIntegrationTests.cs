using MealApplication.Domain.Services;
using System.Linq;
using Xunit;

namespace MealApplication.IntegrationTests
{
    public class MorningIntegrationTests
    {
        [Fact]
        public void Morning_All_Foods()
        {
            var entry = "morning,1,2,3";
            var orderDish = new MakeDish(entry);

            var dish = orderDish.GetDish();
            dish.OutputResult();
            var formatOutput = string.Join(", ", dish.result.ToArray());

            Assert.True(formatOutput == "eggs, toast, coffee");
        }

        [Fact]
        public void Morning_All_Foods_More_Invalid_Input()
        {
            var entry = "morning,1,2,3,4";
            var orderDish = new MakeDish(entry);

            var dish = orderDish.GetDish();
            dish.OutputResult();
            var formatOutput = string.Join(", ", dish.result.ToArray());

            Assert.True(formatOutput == "eggs, toast, coffee, error");
        }

        [Fact]
        public void Morning_Repeat_Twice_Coffee()
        {
            var entry = "morning,1,2,3,3";
            var orderDish = new MakeDish(entry);

            var dish = orderDish.GetDish();
            dish.OutputResult();
            var formatOutput = string.Join(", ", dish.result.ToArray());

            Assert.True(formatOutput == "eggs, toast, coffee(x2)");
        }

        [Fact]
        public void Morning_Repeat_Three_Times_Coffee()
        {
            var entry = "morning,1,2,3,3,3";
            var orderDish = new MakeDish(entry);

            var dish = orderDish.GetDish();
            dish.OutputResult();
            var formatOutput = string.Join(", ", dish.result.ToArray());

            Assert.True(formatOutput == "eggs, toast, coffee(x3)");
        }

        [Fact]
        public void Morning_None_Input()
        {
            var entry = "morning";
            var orderDish = new MakeDish(entry);

            var dish = orderDish.GetDish();
            dish.OutputResult();
            var formatOutput = string.Join(", ", dish.result.ToArray());
            Assert.True(formatOutput.Count() == 0);
        }

        [Fact]
        public void Morning_Only_Eggs_And_Toast()
        {
            var entry = "morning,1,2";
            var orderDish = new MakeDish(entry);

            var dish = orderDish.GetDish();
            dish.OutputResult();
            var formatOutput = string.Join(", ", dish.result.ToArray());

            Assert.True(formatOutput == "eggs, toast");
        }

        [Fact]
        public void Morning_Four_Times_Coffee()
        {
            var entry = "morning,3,3,3,3";
            var orderDish = new MakeDish(entry);

            var dish = orderDish.GetDish();
            dish.OutputResult();
            var formatOutput = string.Join(", ", dish.result.ToArray());

            Assert.True(formatOutput == "coffee(x4)");
        }

        [Fact]
        public void Morning_Dessert_Not_Applicable()
        {
            var entry = "morning,4";
            var orderDish = new MakeDish(entry);

            var dish = orderDish.GetDish();
            dish.OutputResult();
            var formatOutput = string.Join(", ", dish.result.ToArray());

            Assert.True(formatOutput == "error");
        }

        [Fact]
        public void Morning_Invalid_Input()
        {
            var entry = "morning,5";
            var orderDish = new MakeDish(entry);

            var dish = orderDish.GetDish();
            dish.OutputResult();
            var formatOutput = string.Join(", ", dish.result.ToArray());

            Assert.True(formatOutput == "error");
        }
    }
}
