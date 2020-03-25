using Camedia.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Camedia.Models;

namespace Camedia.Controllers
{
	public class CustomersController : Controller
	{
		// GET: Customers
		public ActionResult Index()
		{
			var customers = new Customer();

			var viewModel = new RandomMovieViewModel
			{
				Customers = customers.Customers()
			};

			return View(viewModel);
		}
		[Route("customers/details/{id}")]
		public ActionResult Details(int id)
		{
			var customers = new Customer();

			var viewModel = new RandomMovieViewModel
			{
				Customer = customers.Customers(id)
			};

			if (customers.Customers(id) == "NA")
			{
				return HttpNotFound();
			}
			else
			{
				return View(viewModel);
			}
		}
	}
}