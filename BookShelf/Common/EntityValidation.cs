namespace BookShelf.Common
{
    public static class EntityValidation
    {
        /* Author Begin */
        public const int AuthorNameMinLength = 2;
        public const int AuthorNameMaxLength = 70;
        public const int AuthorCountryMaxLength = 100;
        /* Author End */


        /* Book Begin */
        public const int BookTitleMinLength = 2;
        public const int BookTitleMaxLength = 120;
        /* Book End */
    }
}
