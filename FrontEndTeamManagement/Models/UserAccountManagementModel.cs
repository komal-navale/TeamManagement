using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FrontEndTeamManagement.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username is required.")]
        [RegularExpression(@"^[^<>.,?;:'()!~%\-_@#/*""\s]+$", ErrorMessage = "Special characters are not allowed.")]
        [Display(Name = "Username")]
        [StringLength(15, ErrorMessage = "More than 15 characters are not allowed")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        [Display(Name = "Password")]
        [StringLength(15, ErrorMessage = "The {0} must be {2} to 15 characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Employee ID is required")]
        [RegularExpression(@"^[^<>.,?;:'()!~%\-_@#/*""\s]+$", ErrorMessage = "Special characters are not allowed.")]
        [StringLength(20, ErrorMessage = "More than 20 characters are not allowed.")]
        [Display(Name = "Employee ID")]
        public string EmployeeId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [RegularExpression(@"^[^<>.,?;:'()!~%\-_@#/*""\s]+$", ErrorMessage = "Special characters are not allowed.")]
        [StringLength(20, ErrorMessage = "More than 20 characters are not allowed.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [RegularExpression(@"^[^<>.,?;:'()!~%\-_@#/*""\s]+$", ErrorMessage = "Special characters are not allowed.")]
        [StringLength(20, ErrorMessage = "More than 20 characters are not allowed.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Marital Status is required")]
        [Display(Name = "Marital Status")]
        public string MaritalStatus { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Date Of Birth is required")]
        [Display(Name = "Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Current Address is required")]
        [Display(Name = "Current Address")]
        public string CurrentAddress { get; set; }

        [Required(ErrorMessage = "Pin Code is required.")]
        [Display(Name = "Pin Code")]
        [RegularExpression(@"^[1-9][0-9]{5}$", ErrorMessage = "Pin Code is invalid.")]
        public Int32 PinCode { get; set; }

        [Required(ErrorMessage = "Permanent Address is required")]
        [Display(Name = "Permanent Address")]
        public string PermanentAddress { get; set; }

        [Required(ErrorMessage = "Mobile Number is required.")]
        [Display(Name = "Mobile Number")]
        [RegularExpression(@"[+][9][1][7-9][0-9]{9}$", ErrorMessage = "Mobile Number is invalid.")]
        [StringLength(13, ErrorMessage = "Mobile Number should be of 10 characters long with +91 extension")]
        public string MobileNo { get; set; }


        [Required(ErrorMessage = "Team Role is required")]
        [Display(Name = "Team Role")]
        public string TeamRole { get; set; }

        [Required(ErrorMessage = "Company Name is required")]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Work Experience is required")]
        [Display(Name = "Work Experience")]
        [RegularExpression(@"^(([0-9]{1,2}(\.[0][0-9]))|([0-9]{1,2}(\.[1][0-1])))$", ErrorMessage = "Valid Decimal number with 2 decimal places.")]
        public decimal WorkExperience { get; set; }

        [Required(ErrorMessage = "Technology Known & Worked On is required")]
        [Display(Name = "Technology Known")]
        public string TechnologyKnown { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email Id is required")]
        [Display(Name = "Email Id")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email Format is wrong.")]
        [StringLength(50, ErrorMessage = "Less than 50 characters")]
        public string EmailId { get; set; }


        [Required(ErrorMessage = "Username is required")]
        [RegularExpression(@"^[^<>,?;:'()!~%\-@#/*""\s]+$", ErrorMessage = "Special characters are not allowed.")]
        [StringLength(15, ErrorMessage = "More than 15 characters are not allowed.")]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Passwod is required")]
        [StringLength(15, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirmation of Passwod is required")]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The Password and Confirmation Password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Security Question is required")]
        [Display(Name = "Please select your Security Question?")]
        public string SecurityQuestion { get; set; }


        [Required(ErrorMessage = "Answer for Security Question is required")]
        [Display(Name = "Enter your Answer")]
        public string SecurityAnswer { get; set; }
    }
}