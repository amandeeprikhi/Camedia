﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Camedia.DTOs;
using Camedia.DTOS;
using Camedia.Models;

namespace Camedia.App_Start
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			Mapper.CreateMap<Customer, CustomerDTO>();
			Mapper.CreateMap<CustomerDTO, Customer>()
				.ForMember(c => c.Id, opt => opt.Ignore());
			Mapper.CreateMap<Movie, MovieDTO>();
			Mapper.CreateMap<MovieDTO, Movie>()
				.ForMember(c => c.Id, opt => opt.Ignore());
		}
	}
}