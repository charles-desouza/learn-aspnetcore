using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Services;

namespace OdeToFood.Pages
{
    public class GreetingModel : PageModel
    {
        private readonly IGreeter greeter;
        public string CurrentMessage { get; set; }

        public GreetingModel(IGreeter greeter)
        {
            this.greeter = greeter;
        }
        public void OnGet(string name)
        {
            CurrentMessage = $"{name} : {greeter.GetMessage()}";
        }
    }
}