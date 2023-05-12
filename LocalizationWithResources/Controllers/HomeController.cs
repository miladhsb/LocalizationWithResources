using LocalizationWithResources.Models;

using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using System.Diagnostics;
using System.Reflection;

namespace LocalizationWithResources.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizerFactory _stringLocalizerFactory;
        private readonly IStringLocalizer<HomeController> _stringLocalizer;
        private readonly IHtmlLocalizer<HomeController> _htmlLocalizer;

        public HomeController(ILogger<HomeController> logger, 
            IStringLocalizerFactory stringLocalizerFactory, 
            IStringLocalizer<HomeController> stringLocalizer,
            IHtmlLocalizer<HomeController> htmlLocalizer)
        {
           
            _logger = logger;
            this._stringLocalizerFactory = stringLocalizerFactory;
            this._stringLocalizer = stringLocalizer;
            this._htmlLocalizer = htmlLocalizer;
        }

        public IActionResult Index()
        {
            //LocalizerFactory
            var stringLocalizercreate = _stringLocalizerFactory.Create("Generic.GenericRes", "LocalizationWithResources");
            var name = stringLocalizercreate.GetString("name");
           
            //stringLocalizer
            var Welcome =  _stringLocalizer.GetString("Welcome");
            var Stringpmessage = _stringLocalizer.GetString("p.message");


            //htmlLocalizer
            var pmessage = _htmlLocalizer.GetHtml("p.message").Value;


            //  ResourceManager

            #region note: if in Program.cs has been used RequestLocalizationOptions note need this code
            //Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            #endregion
            
            System.Resources.ResourceManager resourceManager = new System.Resources.ResourceManager("LocalizationWithResources.Resources.Generic.GenericRes", Assembly.GetExecutingAssembly());
            var name2= resourceManager.GetString("name");
            return View();
        }

        public IActionResult Person()
        {
            return View(new PersonModel());
        }

        [HttpPost]
        public IActionResult SetCulture(string culture, string returnUrl)
        {
            Response.Cookies.Append(
           CookieRequestCultureProvider.DefaultCookieName,
           CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
           new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(30) }
       );
            return LocalRedirect(returnUrl);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}