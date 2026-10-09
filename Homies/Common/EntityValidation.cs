namespace Homies.Common
{
    public static class EntityValidation
    {
        // Event Validation
        public const int EventNameMinLength = 5;
        public const int EventNameMaxLength = 20;

        public const int EventDescriptionMinLength = 15;
        public const int EventDescriptionMaxLength = 150;

        public const string EventDateTimeSqlType = "smalldatetime";
        // Event Validation

        // Type Validation
        public const int TypeNameMinLength = 5;
        public const int TypeNameMaxLength = 15;

        // Type Validation
    }
}
