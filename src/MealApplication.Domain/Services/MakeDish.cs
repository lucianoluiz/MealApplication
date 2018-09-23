using MealApplication.Domain.Base;
using MealApplication.Domain.Entities;
using MealApplication.Domain.Enum;

namespace MealApplication.Domain.Services
{
    public class MakeDish : DishPeriod
    {
        public MakeDish(string entry) :
            base(entry)
        {
        }

        public override Dish GetDish()
        {
            var period = Entries[0];

            switch (GetPeriod(period))
            {
                case PeriodEnum.Morning:
                    return new MorningDish(Entries);

                case PeriodEnum.Night:
                    return new NightDish(Entries);

                default:
                    return null;
            }
        }

        private PeriodEnum GetPeriod(string period)
        {
            switch (period.ToUpper())
            {
                case "MORNING":
                    return PeriodEnum.Morning;
                case "NIGHT":
                    return PeriodEnum.Night;
                default: return PeriodEnum.Invalid;
            }
        }
    }
}
