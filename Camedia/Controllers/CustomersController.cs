using Camedia.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Camedia.Models;

namespace Camedia.Controllers
{
	public class CustomersController : Controller
	{
		private ApplicationDbContext _context;

		public CustomersController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		// GET: Customers
		public ViewResult Index()
		{
			var customers = _context.Customers.Include(c => c.MembershipType).ToList();

			//var viewModel = new RandomMovieViewModel
			//{
			//	Customers = customers
			//};

			return View(customers);
		}
		[Route("customers/details/{id}")]
		public ActionResult Details(int id)
		{
			var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

			//var viewModel = new RandomMovieViewModel
			//{
			//	Customer = customers.Customers(id)
			//};

			if (customer == null)
			{
				return HttpNotFound();
			}
			else
			{
				return View(customer);
			}
		}
	}
}