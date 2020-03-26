using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Camedia.Models;
using Camedia.ViewModels;

namespace Camedia.Controllers
{
	public class MoviesController : Controller
	{
		private ApplicationDbContext _context;

		public MoviesController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		public ViewResult New() {

			var genres = _context.Genres.ToList();

			var viewModel = new MovieFormViewModel {
				Genres = genres
			};

			return View("MovieForm", viewModel);
		}

		public ActionResult Edit(int id)
		{
			var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

			if (movie == null)
				return HttpNotFound();

			var viewModel = new MovieFormViewModel
			{
				Movie = movie,
				Genres = _context.Genres.ToList()
			};

			return View("MovieForm", viewModel);
		}

		[HttpPost]
		public ActionResult Save(Movie movie)
		{
			if (movie.Id == 0)
			{
				movie.DateAdded = DateTime.Now;
				_context.Movies.Add(movie);
			}
			else
			{
				var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
				movieInDb.Name = movie.Name;
				movieInDb.GenreId = movie.GenreId;
				movieInDb.NumberInStock = movie.NumberInStock;
				movieInDb.ReleaseDate = movie.ReleaseDate;
				movieInDb.Genre = movie.Genre;
			}

			_context.SaveChanges();

			return RedirectToAction("Index", "Movies");
		}

		public ViewResult Index()
		{
			var movies = _context.Movies.Include(m => m.Genre).ToList();

			//var viewModel = new RandomMovieViewModel
			//{
			//	Movies = movies.Movies()
			//};

			return View(movies);
		}

		[Route("movies/details/{id}")]
		public ActionResult Details(int id)
		{
			var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

			var genres = _context.Genres.ToList();

			var viewModel = new MovieFormViewModel
			{
				Genres = genres,
				Movie = movie
			};

			if (movie == null)
			{
				return HttpNotFound();
			}
			else
			{
				return View("MovieForm", viewModel);
			}
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
		//public ActionResult Edit(int id)
		//{
		//	return Content("id = " + id);
		//}

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