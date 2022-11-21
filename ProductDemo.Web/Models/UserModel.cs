using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductDemo.Web.Models
{
    public class UserModel
    {
        public int UserId { get; set; }

        [Display(Name = "User Name")] //used for dynamic changes in MVC
        [Required(AllowEmptyStrings = false,ErrorMessage ="Please enter UserName")]
        [StringLength(20,MinimumLength =5,ErrorMessage ="UserName should be min 5 and max 20 characters long")]
        public string UserName { get; set; }

       
        [Display(Name = "Mobile")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter Mobile")]
        [RegularExpression(("^\\+?[1-9][0-9]{7,14}$"), ErrorMessage = "Please enter valid Mobile No")]
        public int Mobile { get; set; }

        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter Email")]
        [RegularExpression(("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$"),ErrorMessage ="Enter Valid Email")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter Password")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$")]
        public string Password { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Please enter Gender")]
        public string Gender { get; set; }
        
    }
}