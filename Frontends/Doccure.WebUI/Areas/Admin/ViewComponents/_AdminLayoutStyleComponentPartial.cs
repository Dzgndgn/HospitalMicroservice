using Microsoft.AspNetCore.Mvc;

namespace Doccure.WebUI.Areas.Admin.ViewComponents
{
    public class _AdminLayoutStyleComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(
                "~/Areas/Admin/Views/Shared/Components/" +
            "_AdminLayoutStyleComponentPartial/Default.cshtml");
        }
    }
}
