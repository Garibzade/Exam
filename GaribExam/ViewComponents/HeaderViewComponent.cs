﻿using Microsoft.AspNetCore.Mvc;

namespace GaribExam.ViewComponents
{
	public class HeaderViewComponent:ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View();
		}
	}
}