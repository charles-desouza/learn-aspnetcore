using OdeToFood.Services;
using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.ViewComponents
{
    public class GreeterOneViewComponent : ViewComponent
    {
        private readonly IGreeter _greeter;

        public GreeterOneViewComponent(IGreeter greeter)
        {
            _greeter = greeter;
        }

        public IViewComponentResult Invoke()
        {
            var model = _greeter.GetMessage();
            return View("Default",model);
        }
    }
}