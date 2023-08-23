using System;
using System.ComponentModel.DataAnnotations;

namespace MailingList.Models
{
	public class Contact
	{
        [Required]
        [RegularExpression(@"^\S*$", ErrorMessage = "Whitespace is not allowed.")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"^\S*$", ErrorMessage = "Whitespace is not allowed.")]
        public string LastName { get; set; }
        [Key]
        [Required]
        [RegularExpression(@"^\S*$", ErrorMessage = "Whitespace is not allowed.")]
        public string Email { get; set; }
	}
}

