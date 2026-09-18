namespace GarageApp.Common
{
    public static class EntityValidation
    {
        /* Car Begin */
        public const int CarMakeMinLength = 1;
        public const int CarMakeMaxLength = 70;

        public const int CarModelMinLength = 1;
        public const int CarModelMaxLength = 70;

        public const int CarProductionMonthMinValue = 1;
        public const int CarProductionMonthMaxValue = 12;

        public const int CarYearMinValue = 1900;
        /* Car End */

        /* Garage Begin */
        public const int GarageNameMinLength = 1;
        public const int GarageNameMaxLength = 100;

        public const int GarageLocationMinLength = 5;
        public const int GarageLocationMaxLength = 100;
        /* Garage End */
    }
}