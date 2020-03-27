﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Camedia.Models
{
	public class Min18YrsIfAMember : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var customer = (Customer)validationContext.ObjectInstance;
			if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
				return ValidationResult.Success;
			if (customer.DateOfBirth == null)
				return new ValidationResult("Date of Birth is required.");

			var age = DateTime.Today.Year - customer.DateOfBirth.Value.Year;

			return (age >= 18) 
				? ValidationResult.Success 
				: new ValidationResult("Customer should be atleast 18 years old to become a member.");
			
		}
	}
}