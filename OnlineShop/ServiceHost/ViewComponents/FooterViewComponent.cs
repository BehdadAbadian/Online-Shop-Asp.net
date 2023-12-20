using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace ServiceHost.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
