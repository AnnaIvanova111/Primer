using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Phone.Models;
using Phone.Models.ViewModels;

namespace Phone.Controllers
{
    public class HomeController : Controller
    {
        List<Phone1> phones;
        List<Company> companies;
        public HomeController()
        {
            Company apple = new Company { Id = 1, Name = "Apple", Country = "США" };
            Company microsoft = new Company { Id = 2, Name = "Samsung", Country = "Республика Корея" };
            Company google = new Company { Id = 3, Name = "Google", Country = "США" };
            companies = new List<Company> { apple, microsoft, google };

            phones = new List<Phone1>
            {
                new Phone1 { Id=1, Manufacturer= apple, Name="iPhone X", Price=56000 },
                new Phone1 { Id=2, Manufacturer= apple, Name="iPhone XZ", Price=41000 },
                new Phone1 { Id=3, Manufacturer= microsoft, Name="Galaxy 9", Price=9000 },
                new Phone1 { Id=4, Manufacturer= microsoft, Name="Galaxy 10", Price=40000 },
                new Phone1 { Id=5, Manufacturer= google, Name="Pixel 2", Price=30000 },
                new Phone1 { Id=6, Manufacturer= google, Name="Pixel XL", Price=50000 }
            };
        }

        public IActionResult GetPhones(Phone1[] phones)
        {
            string result = "";
            foreach (var p in phones)
                result = $"{result}{p.Name} - {p.Price} - {p.Manufacturer?.Name} \n";
            return Content(result);
        }


        public IActionResult Index(int? companyId)
         {
             // формируем список компаний для передачи в представление
             List<CompanyModel> compModels = companies
                 .Select(c => new CompanyModel { Id = c.Id, Name = c.Name })
                 .ToList();
             // добавляем на первое место
             compModels.Insert(0, new CompanyModel { Id = 0, Name = "Все" });

             IndexViewModel ivm = new IndexViewModel { Companies = compModels, Phones = phones };

             // если передан id компании, фильтруем список
             if (companyId != null && companyId > 0)
                 ivm.Phones = phones.Where(p => p.Manufacturer.Id == companyId);

             return View(ivm);
         }

    }
}
