using MealApplication.Domain.Services;
using System.Linq;
using Xunit;

namespace MealApplication.IntegrationTests
{
    public class NightIntegrationTests
    {
        [Fact]
        public void Night_All_Foods()
        {
            var entry = "night,1,2,3,4";
            var orderDish = new MakeDish(entry);

            var dish = orderDish.GetDish();
            dish.OutputResult();
            var formatOutput = string.Join(", ", dish.result.ToArray());

            Assert.True(formatOutput == "steak, potato, wine, cake");
        }

        [Fact]
        public void Night_All_Foods_More_Invalid_Input()
        {
            var entry = "night,1,2,3,4,5";
            var orderDish = new MakeDish(entry);

            var dish = orderDish.GetDish();
            dish.OutputResult();
            var formatOutput = string.Join(", ", dish.result.ToArray());
            Assert.True(formatOutput == "steak, potato, wine, cake, error");
        }

        [Fact]
        public void Night_Repeat_Twice_Potato()
        {
            var entry = "night,1,2,2,3";
            var orderDish = new MakeDish(entry);

            var dish = orderDish.GetDish();
            dish.OutputResult();
            var formatOutput = string.Join(", ", dish.result.ToArray());

            Assert.True(formatOutput == "steak, potato(x2), wine");
        }

        [Fact]
        public void Night_Repeat_Three_Times_Potato()
        {
            var entry = "night,1,2,2,2,3";
            var orderDish = new MakeDish(entry);

            var dish = orderDish.GetDish();
            dish.OutputResult();
            var formatOutput = string.Join(", ", dish.result.ToArray());

            Assert.True(formatOutput == "steak, potato(x3), wine");
        }

        [Fact]
        public void Night_None_Input()
        {
            var entry = "night";
            var orderDish = new MakeDish(entry);

            var dish = orderDish.GetDish();
            dish.OutputResult();
            var formatOutput = string.Join(", ", dish.result.ToArray());

            Assert.True(formatOutput.Count() == 0);
        }

        [Fact]
        public void Night_Only_Steak_And_Potato()
        {
            var entry = "night,1,2";
            var orderDish = new MakeDish(entry);

            var dish = orderDish.GetDish();
            dish.OutputResult();
            var formatOutput = string.Join(", ", dish.result.ToArray());

            Assert.True(formatOutput == "steak, potato");
        }

        [Fact]
        public void Night_Four_Times_Potato()
        {
            var entry = "night,2,2,2,2";
            var orderDish = new MakeDish(entry);

            var dish = orderDish.GetDish();
            dish.OutputResult();
            var formatOutput = string.Join(", ", dish.result.ToArray());

            Assert.True(formatOutput == "potato(x4)");
        }

        [Fact]
        public void Night_Have_Dessert()
        {
            var entry = "night,4";
            var orderDish = new MakeDish(entry);

            var dish = orderDish.GetDish();
            dish.OutputResult();
            var formatOutput = string.Join(", ", dish.result.ToArray());

            Assert.True(formatOutput == "cake");
        }

        [Fact]
        public void Night_Invalid_Input()
        {
            var entry = "night,5";
            var orderDish = new MakeDish(entry);

            var dish = orderDish.GetDish();
            dish.OutputResult();
            var formatOutput = string.Join(", ", dish.result.ToArray());

            Assert.True(formatOutput == "error");
        }
    }
}
