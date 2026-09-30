namespace EventManager.Common
{
    public static class EntityValidation
    {
        public static class Event
        {
            public const int TitleMinLength = 3;
            public const int TitleMaxLength = 120;

            public const int DescriptionMaxLength = 700;
        }

        public static class Category
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 75;
        }

        public static class Registration
        {
            public const int ParticipantNameMinLength = 5;
            public const int ParticipantNameMaxLength = 75;

            public const int EmailMinLength = 5;
            public const int EmailMaxLength = 150;
        }
    }
}
