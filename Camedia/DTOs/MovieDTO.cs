﻿using Camedia.DTOs;
using System;
using System.ComponentModel.DataAnnotations;

namespace Camedia.DTOS
{
	public class MovieDTO
	{
		public int Id { get; set; }

		[Required]
		[StringLength(255)]
		public string Name { get; set; }

		[Required]
		public byte GenreId { get; set; }

		public GenreDTO Genre { get; set; }

		public DateTime DateAdded { get; set; }

		public DateTime ReleaseDate { get; set; }

		[Range(1, 20)]
		public byte NumberInStock { get; set; }
	}
}