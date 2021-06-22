using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XPTOChallenge.Models;

namespace XPTOChallenge.Controllers
{
    public class ListagemOSController : Controller
    {
        public IActionResult Index()
        {
            List<OrdemServico> ordem = new List<OrdemServico>();
            var dateString = "5/1/2008 8:30:52 AM";
            ordem.Add(new OrdemServico (
                12,
                "1123",
                "123123ssss132",
                9949.0,
                DateTime.Parse(dateString,
                          System.Globalization.CultureInfo.InvariantCulture),
                "Jão",
                "Depra",
                "Seila tlgd"
            ));
            ordem.Add(new OrdemServico (
                12,
                "1123",
                "123123ssss132",
                9949.0,
                DateTime.Parse(dateString,
                          System.Globalization.CultureInfo.InvariantCulture),
                "Jão",
                "Depra",
                "Seila tlgd"
            ));
            ordem.Add(new OrdemServico (
                12,
                "1123",
                "123123ssss132",
                9949.0,
                DateTime.Parse(dateString,
                          System.Globalization.CultureInfo.InvariantCulture),
                "Jão",
                "Depra",
                "Seila tlgd"
            ));
            return View(ordem);
        }
    }
}
