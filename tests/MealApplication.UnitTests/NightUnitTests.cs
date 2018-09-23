using MealApplication.Domain.Entities;
using System.Linq;
using Xunit;

namespace MealApplication.UnitTests
{
    public class NightUnitTests
    {
        [Fact]
        public void Night_All_Foods()
        {
            var entry = "night,1,2,3,4";
            var entryList = entry.Split(',').ToList();

            var NightDishes = new NightDish(entryList);
            NightDishes.OutputResult();
            var formatOutput = string.Join(", ", NightDishes.result.ToArray());

            Assert.True(formatOutput == "steak, potato, wine, cake");
        }

        [Fact]
        public void Night_All_Foods_More_Invalid_Input()
        {
            var entry = "night,1,2,3,4,5";
            var entryList = entry.Split(',').ToList();

            var NightDishes = new NightDish(entryList);
            NightDishes.OutputResult();
            var formatOutput = string.Join(", ", NightDishes.result.ToArray());

            Assert.True(formatOutput == "steak, potato, wine, cake, error");
        }

        [Fact]
        public void Night_Repeat_Twice_Potato()
        {
            var entry = "night,1,2,2,3";
            var entryList = entry.Split(',').ToList();

            var NightDishes = new NightDish(entryList);
            NightDishes.OutputResult();
            var formatOutput = string.Join(", ", NightDishes.result.ToArray());

            Assert.True(formatOutput == "steak, potato(x2), wine");
        }

        [Fact]
        public void Night_Repeat_Three_Times_Potato()
        {
            var entry = "night,1,2,2,2,3";
            var entryList = entry.Split(',').ToList();

            var NightDishes = new NightDish(entryList);
            NightDishes.OutputResult();
            var formatOutput = string.Join(", ", NightDishes.result.ToArray());

            Assert.True(formatOutput == "steak, potato(x3), wine");
        }

        [Fact]
        public void Night_None_Input()
        {
            var entry = "night";
            var entryList = entry.Split(',').ToList();

            var NightDishes = new NightDish(entryList);
            NightDishes.OutputResult();
            var formatOutput = string.Join(", ", NightDishes.result.ToArray());

            Assert.True(formatOutput.Count() == 0);
        }

        [Fact]
        public void Night_Only_Steak_And_Potato()
        {
            var entry = "night,1,2";
            var entryList = entry.Split(',').ToList();

            var NightDishes = new NightDish(entryList);
            NightDishes.OutputResult();
            var formatOutput = string.Join(", ", NightDishes.result.ToArray());

            Assert.True(formatOutput == "steak, potato");
        }

        [Fact]
        public void Night_Four_Times_Potato()
        {
            var entry = "night,2,2,2,2";
            var entryList = entry.Split(',').ToList();

            var NightDishes = new NightDish(entryList);
            NightDishes.OutputResult();
            var formatOutput = string.Join(", ", NightDishes.result.ToArray());

            Assert.True(formatOutput == "potato(x4)");
        }

        [Fact]
        public void Night_Have_Dessert()
        {
            var entry = "night,4";
            var entryList = entry.Split(',').ToList();

            var NightDishes = new NightDish(entryList);
            NightDishes.OutputResult();
            var formatOutput = string.Join(", ", NightDishes.result.ToArray());

            Assert.True(formatOutput == "cake");
        }

        [Fact]
        public void Night_Invalid_Input()
        {
            var entry = "night,5";
            var entryList = entry.Split(',').ToList();

            var NightDishes = new NightDish(entryList);
            NightDishes.OutputResult();
            var formatOutput = string.Join(", ", NightDishes.result.ToArray());

            Assert.True(formatOutput == "error");
        }
    }
}
