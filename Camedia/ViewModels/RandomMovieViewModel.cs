using Camedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Camedia.ViewModels
{
	public class RandomMovieViewModel
	{
		public Movie Movie { get; set; }

		public List<Customer> Customers { get; set; }

		public string Customer { get; set; }

		public List<Movie> Movies { get; set; }
	}
}