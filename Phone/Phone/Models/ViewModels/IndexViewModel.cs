using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Phone.Models;



namespace Phone.Models.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Phone1> Phones { get; set; }
        public IEnumerable<CompanyModel> Companies { get; set; }
    }
}
