using System;
using System.ComponentModel.DataAnnotations;
using WebApplication.ViewModels;

namespace ChickenScratch.Web.ViewModels.Customer
{
    public class CustomerViewModel : ViewModelBase
    {
        public Int32 CustomerId { get; set; }

        [Required(ErrorMessage = "Name")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Name cannot be longer than 100 characters.")]
        [Display(Name = "Name")]
        public String Name { get; set; }

        
        [Required(ErrorMessage = "Token Secret")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "Token Secret cannot be longer than 100 characters.")]
        [Display(Name = "Token Secret")]
        public String TokenSecret { get; set; }
    }
}