using System.ComponentModel.DataAnnotations;

namespace Demo.Pages.PageModels
{
    public class DemoForm
    {
        [Required]
        public string SelectedDemoModelName { get; set; }
    }
}
