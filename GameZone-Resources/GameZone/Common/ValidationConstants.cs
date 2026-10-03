namespace GameZone.Common
{
    public static class ValidationConstants
    {
        // Genre Validation Begin
        public const int GenreNameMinLength = 3;
        public const int GenreNameMaxLength = 70;
        // Genre Validation End

        // Game Validation Begin
        public const int GameTitleMinLength = 2;
        public const int GameTitleMaxLength = 120;

        public const int GameDescriptionMinLength = 20;
        public const int GameDescriptionMaxLength = 1000;

        public const int GameImageUrlMaxLength = 2000;

        public const int GamePublisherMinLength = 3;
        public const int GamePublisherMaxLength = 100;
        // Game Validation End
    }
}
