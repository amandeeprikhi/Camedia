﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Camedia.Models
{
	public class Customer
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Please enter the customer's name.")]
		[StringLength(255)]
		public string Name { get; set; }

		public bool IsSubscribedToNewsLetter { get; set; }

		public MembershipType MembershipType { get; set; }

		[Display(Name="Membership Type")]
		public byte MembershipTypeId { get; set; }

		[Display(Name = "Date of Birth")]
		[Min18YrsIfAMember]
		public DateTime? DateOfBirth { get; set; }

		public List<Customer> Customers()
		{
			var customers = new List<Customer> {
				new Customer { Id = 1, Name = "Aman"},
				new Customer { Id = 2, Name = "Test"}
			};

			return customers;
		}

		public String Customers(int id)
		{
			var customers = new List<Customer> {
				new Customer { Id = 1, Name = "Aman"},
				new Customer { Id = 2, Name = "Test"}
			};

			try
			{
				return customers[id - 1].Name;
			}
			catch (Exception)
			{
				return "NA";
				throw;
			}
		}
	}
}