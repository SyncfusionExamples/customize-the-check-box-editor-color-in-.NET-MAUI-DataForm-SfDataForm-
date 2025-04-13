using Syncfusion.Maui.DataForm;
using System.ComponentModel.DataAnnotations;

namespace CustomizeCheckBoxColor
{
    public class DataFormModel
    {
        public DataFormModel()
        {
            this.Name = string.Empty;
            this.Address = string.Empty;
            this.City = string.Empty;
            this.Country = string.Empty;
            this.BirthDate = string.Empty;
        }

        [Display(Prompt = "Enter your name")]
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Display(Prompt = "Enter your address", Name = "Address")]
        [Required(ErrorMessage = "Please enter your address")]
        public string Address { get; set; }

        [Display(Prompt = "Select a gender")]
        [Required(ErrorMessage = "Please select a gender")]
        public Gender Gender { get; set; }
        public string BirthDate { get; set; }
        public bool FirstGraduate { get; set; }
        public bool ReadyToRelocate { get; set; }

        [Display(Prompt = "Enter your city")]
        [Required(ErrorMessage = "Please enter your city")]
        public string City { get; set; }

        [Display(Prompt = "Enter your country")]
        [Required(ErrorMessage = "Please select your country")]
        public string Country { get; set; }

    }
    public enum Gender
    {
        Male,
        Female,
        Others
    }
}