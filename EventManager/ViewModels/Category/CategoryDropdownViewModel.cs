namespace EventManager.ViewModels.Category
{
    public class CategoryDropdownViewModel
    {
        // Data direction is Server to Client => no Model Validation is required

        public int Id
        {
            get; set;
        }
        public string Name
        {
            get; set;
        } = null!;
    }
}
