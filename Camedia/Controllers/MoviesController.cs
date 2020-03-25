﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Camedia.Models;
using Camedia.ViewModels;

namespace Camedia.Controllers
{
	public class MoviesController : Controller
	{
		public ActionResult Index()
		{
			var movies = new Movie();

			var viewModel = new RandomMovieViewModel
			{
				Movies = movies.Movies()
			};

			return View(viewModel);
		}
		// GET: Movies/Random
		public ActionResult Random()
		{
			var movie = new Movie()
			{
				Name = "Contagion"
			};

			var customers = new List<Customer> {
				new Customer { Name = "Aman"},
				new Customer { Name = "Testing"}
			};

			var viewModel = new RandomMovieViewModel
			{
				Movie = movie,
				Customers = customers
			};

			return View(viewModel);
		}
		public ActionResult Edit(int id)
		{
			return Content("id = " + id);
		}

		//Removed for now
		//public ActionResult Index(int? pageIndex, string sortBy) {
		//	if (!pageIndex.HasValue)
		//		pageIndex = 1;

		//	if (String.IsNullOrWhiteSpace(sortBy))
		//		sortBy = "Name";

		//	return Content(String.Format("pageIndex = {0} & sortBy = {1}", pageIndex, sortBy));
		//}


		[Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")]
		public ActionResult ByReleaseDate(int year, int month)
		{
			return Content(year + "/" + month);
		}

	}
}