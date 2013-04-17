
namespace BootStrapHtmlExtensions.Tests.TestModels
{
    using System.ComponentModel.DataAnnotations;

    public class Contact
    {
        public int Id { get; set; }

        [Display(Name="First Name")]
        [Required]
        public string FirstName { get; set; }
    }
}
