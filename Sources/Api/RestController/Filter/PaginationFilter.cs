using System;
using Microsoft.AspNetCore.Mvc;

namespace RestController.Filter
{
	public class PaginationFilter
	{

		[FromQuery(Name= "page")]
		public int Page
		{
			get => _page;
			set => _page = value < 1 ? _page : value;
		}

		private int _page = 1;

		[FromQuery(Name = "count")]
		public int Count
		{
			get => _count;
			set => _count = value < 1 ? _count : value;

		}

		private int _count = 10;

	}
}

