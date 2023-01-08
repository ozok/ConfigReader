using System.ComponentModel.DataAnnotations;

namespace WebEditor.ViewModels
{
    public class ConfigurationAddViewModel
    {

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        [StringLength(128)]
        public string Value { get; set; }

        [Required]
        [StringLength(128)]
        public string ApplicationName { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
