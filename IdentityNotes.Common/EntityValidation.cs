namespace IdentityNotes.Common
{
    public static class EntityValidation
    {
        public static class User
        {
            public const int UsernameMinLength = 3;
            public const int UsernameMaxLength = 256;
        }

        public static class Note
        {
            public const int TitleMinLength = 3;
            public const int TitleMaxLength = 50;
            public const int ContentMinLength = 5;
            public const int ContentMaxLength = 500;
            public const string CreatedOnColumnType = "smalldatetime";
        }
    }
}
