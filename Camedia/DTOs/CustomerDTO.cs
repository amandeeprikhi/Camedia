using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Camedia.Models;

namespace Camedia.DTOs
{
	public class CustomerDTO
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Please enter the customer's name.")]
		[StringLength(255)]
		public string Name { get; set; }

		public bool IsSubscribedToNewsLetter { get; set; }

		public byte MembershipTypeId { get; set; }

		//[Min18YrsIfAMember]
		public DateTime? DateOfBirth { get; set; }
	}
}