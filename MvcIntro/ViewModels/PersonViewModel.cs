namespace MvcIntro.ViewModels
{
    public class PersonViewModel
    {
        public int Id
        {
            get; set;
        }

        public required string FirstName
        {
            get;
            set;
        }

        public required string LastName
        {
            get;
            set;
        }

        public int Age
        {
            get; set;
        }
    }
}
