using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestTask.App.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

//    //Попробовал набросать пример, думаю, общий подход из него будет ясен.Слоев абстракции должно быть несколько, и продумайте принципы сериализации моделей и механизм построения URL.

//public class TestController : Controller
//    {
//        private readonly ISingInTask _singInTask;

//        public TestController()
//        {
//            _singInTask = new SingInTask();
//        }

//        [ValidateModel]
//        [HandleAllExceptions]
//        public ActionResult SignIn(SignInModel model)
//        {
//            _singInTask.SignIn(model.UserName, model.Password);
//        }
//    }

//    public class SingInTask : BaseRestWrapper, ISingInTask
//    {
//        public void SignIn(string userName, string password)
//        {
//            var uri = UriHelper.CreateUri("api/signin");
//            var result = base.Post<SignInRestServiseResponseModel>(
//                uri,
//                new { userName, password },
//                null);

//            if (result != null && string.IsNullOrEmpty(result.ErrorMessage))
//            {
//                return;
//            }

//            throw new AuthenticationException(result.ErrorMessage);
//        }
//    }

//    public abstract class BaseRestWrapper : ApiClient
//    {
//        public BaseRestWrapper()
//        {
//            Client = new HttpClient
//            {
//                BaseAddress = new Uri(
//                    ConfigurationManager.AppSettings["BaseUrl"].TrimEnd('/'))
//            };
//        }

//        public HttpClient Client { get; set; }

//        public HttpResponseMessage Post(Uri uri, object model, object uriModel)
//        {
//            var requestUri = uri;

//            if (uriModel != null)
//            {
//                requestUri = AddModelToUri(uri, uriModel);
//            }

//            var responce = Client.PostAsJsonAsync(requestUri.ToString(), model).Result;
//            return responce;
//        }

//        private static Uri AddModelToUri(Uri uri, object model)
//        {
//            var prms = model
//                .GetType()
//                .GetProperties()
//                .Select(item => new { item.Name, Value = item.GetValue(model) })
//                .Where(item => item.Value != null)
//                .ToDictionary(item => item.Name, item => item.Value.ToString());

//            var builder = new UriBuilder(uri);

//            foreach (var prm in prms)
//            {
//                builder.SetQueryParam(prm.Key, prm.Value);
//            }

//            return builder.Uri;
//        }
//    }
}