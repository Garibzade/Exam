using Microsoft.AspNetCore.Mvc;

namespace GaribExam.ViewComponents
{
	public class FooterViewComponent:ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View();
		}
	}
}
