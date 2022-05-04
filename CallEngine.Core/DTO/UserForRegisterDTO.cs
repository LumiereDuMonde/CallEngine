using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CallEngine.Core
{
	public class UserForRegisterDTO
	{
		[Required]
		[StringLength(25, MinimumLength = 6, ErrorMessage = "You must specify a username between 6 and 25 characters")]
		public string Username { get; set; }

		[Required]
		[StringLength(25, MinimumLength = 8, ErrorMessage = "You must specify a password between 8 and 25 characters")]
		public string Password { get; set; }

		[Required]
		[DataType(DataType.EmailAddress)]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.PhoneNumber)]
		[Phone]
		public string Phonenumber { get; set; }
	}
}
