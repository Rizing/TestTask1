using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TestTask.Service.WebApi2.Models;

namespace TestTask.Service.WebApi2.Controllers
{
    public class ProductsFilterController : ApiController
    {
        //Я избегаю хитростей получения аргументов и одновременных маршрутов, работающих над несколькими действиями, 
        //Сложные маршруты перед аргументами - это боль :)
        //Поэтому выделил один из POST запросов (2 POST запроса проходят по одному MapHttpRoute) в отдельный контроллер.

        private TestDBEntities db = new TestDBEntities();

        //•	POST-метод получения списка изделий по переданному фильтру(по наименованию изделия).cket\source\repos\TestTask
        public IEnumerable<Product> PostProduct(string name)
        {
            return db.Products.Where(p => p.Name.StartsWith(name)).OrderBy(p => p);
        }
    }
}
