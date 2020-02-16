using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Primer_9.Models;

namespace Primer_9.Controllers
{
    public class HomeController : Controller
    {
        //   public IActionResult Index()
        //  {
        //      return View();
        //  }

        public IActionResult Index()
        {
            return RedirectToRoute("default", new { controller = "Home", action = "Area", height = 2, altitude = 20 });
        }
        public IActionResult Area(int altitude, int height)
        {
            double area = altitude * height / 2;
            return Content($"Площадь треугольника с основанием {altitude} и высотой {height} равна {area}");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

     /*   public string Area()
        {
            string altitudeString = Request.Query.FirstOrDefault(p => p.Key == "altitude").Value;
            int altitude = Int32.Parse(altitudeString);

            string heightString = Request.Query.FirstOrDefault(p => p.Key == "height").Value;
            int height = Int32.Parse(heightString);

            double square = altitude * height / 2;
            return $"Площадь треугольника с основанием {altitude} и высотой {height} равна {square}";
        }*/

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }





      /*  public JsonResult GetName()
        {
            string name = "Tom";
            return Json(name);
        }
        public JsonResult GetUser()
        {
            User user = new User { Name = "Tom", Age = 28 };
            return Json(user);
        }*/
    }
    


 /*  public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    */

    /* public class Geometry
     {
         public int Altitude { get; set; } // основание
         public int Height { get; set; } // высота

         public double GetArea() // вычисление площади треугольника
         {
             return Altitude * Height / 2;
         }
     }*/
}
