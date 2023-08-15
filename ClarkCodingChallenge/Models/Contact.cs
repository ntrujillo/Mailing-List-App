using System;
using System.ComponentModel.DataAnnotations;

namespace ClarkCodingChallenge.Models
{
	public class Contact
	{
		// excluding ID for simplicity sake since functionality doesn't require it
		public string FirstName { get; set; }
		public string LastName { get; set; }
        [Key]
        public string Email { get; set; }
	}
}

