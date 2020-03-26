using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Camedia.Models
{
	public class Movie
	{
		public int Id { get; set; }
		public string Name { get; set; }

		[Display(Name = "Release Date")]
		public DateTime ReleaseDate { get; set; }

		public DateTime DateAdded { get; set; }

		[Display(Name = "Number in Stock")]
		public int NumberInStock { get; set; }

		public Genre Genre { get; set; }

		public byte GenreId { get; set; }

		public List<Movie> Movies()
		{
			var movies = new List<Movie>
			{
				new Movie { Id = 1, Name = "Contagion"},
				new Movie { Id = 2, Name = "Star Trek"}
			};

			return movies;
		}
	}
}