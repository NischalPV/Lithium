using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Lithium.Identity.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public DateTime CreatedDate { get; private set; }

		[NotMapped]
		public string FullName => $"{FirstName} {LastName}";

		public ApplicationUser() => CreatedDate = DateTime.UtcNow;

        public ApplicationUser(DateTime? createdDate = null) => CreatedDate = createdDate ?? DateTime.UtcNow;
    }
}

