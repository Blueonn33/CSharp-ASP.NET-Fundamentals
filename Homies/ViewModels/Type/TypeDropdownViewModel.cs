namespace Homies.ViewModels.Type
{
    public class TypeDropdownViewModel
    {
        // Data flow is from TRUSTED Server to UNTRUSTED Client
        public int Id
        {
            get; set;
        }

        public string Name { get; set; } = null!;
    }
}
