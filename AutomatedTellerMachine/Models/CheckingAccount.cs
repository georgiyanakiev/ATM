using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutomatedTellerMachine.Models
{
    public class CheckingAccount
    {   
       
        public int Id { get; set; }
        [Required]
        //[StringLength(10,MinimumLength =6)]
        [RegularExpression(@"\d{6,10}", ErrorMessage = "Account # must be between 6 and 10 digits.")]
        public string AccountNumber { get; set; }
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Last Name ")]
        [Required]
        public string LastName { get; set; }
        public string Name
        {
            get
            {
                return string.Format("{0} {1}", this.FirstName, this.LastName);
            }

        }
        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }
    }
}