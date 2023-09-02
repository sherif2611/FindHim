using Microsoft.AspNetCore.Mvc;
using Project1.Models;
using Project1.ViewModels;
using System.Diagnostics;
using System.Net.WebSockets;

namespace Project1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(Search search)
        {
            if (search.Gender==null&&search.Govern==null&&search.Date==null&&search.Ciry==null&&search.NameOrAge==null)
            {
                var context = new FindHimDbContext();
                ViewData["people"] = context.MissingPeople.ToList();
                return View("index");
            }
            else
            {
                if (search.NameOrAge == null)
                {
                    var context = new FindHimDbContext();
                    /*
                     *  A = City 
                     *  B = Gender
                     *  C = Date
                     *  D = Govern
                     */

                    //ABCD
                    if (search.Ciry != null && search.Gender != null && search.Date != null && search.Govern != null)
                    {

                        ViewData["people"] = context.MissingPeople
                            .Where(
                            a => a.FoundCity == search.Ciry &&
                            a.FoundGovern == search.Govern &&
                            a.Date == search.Date && a.Gender == search.Gender)
                            .ToList();
                        return View("index");
                    }
                    //BCD
                    else if (search.Gender != null && search.Date != null && search.Govern != null && search.Ciry == null)
                    {
                        ViewData["people"] = context.MissingPeople
                        .Where(a =>
                        a.FoundGovern == search.Govern &&
                        a.Date == search.Date && a.Gender == search.Gender)
                        .ToList();
                        return View("index");
                    }
                    //CD
                    else if (search.Date != null && search.Govern != null && search.Ciry == null && search.Gender == null)
                    {
                        ViewData["people"] = context.MissingPeople
                        .Where(
                        a =>
                        a.FoundGovern == search.Govern &&
                        a.Date == search.Date)
                        .ToList();
                        return View("index");
                    }
                    //D
                    else if (search.Govern != null && search.Ciry == null && search.Gender == null && search.Date == null)
                    {
                        ViewData["people"] = context.MissingPeople
                        .Where(
                        a =>
                        a.FoundGovern == search.Govern
                        )
                        .ToList();
                        return View("index");
                    }
                    //ACD
                    else if (search.Ciry != null && search.Date != null && search.Govern != null && search.Gender == null)
                    {
                        ViewData["people"] = context.MissingPeople
                        .Where(
                        a => a.FoundCity == search.Ciry &&
                        a.FoundGovern == search.Govern &&
                        a.Date == search.Date)
                        .ToList();
                        return View("index");
                    }
                    //AD
                    else if (search.Ciry != null && search.Govern != null && search.Date == null && search.Gender == null)
                    {
                        ViewData["people"] = context.MissingPeople
                        .Where(
                        a => a.FoundCity == search.Ciry &&
                        a.FoundGovern == search.Govern
                        )
                        .ToList();
                        return View("index");
                    }
                    //ABD
                    else if (search.Ciry != null && search.Gender != null && search.Govern != null && search.Date == null)
                    {
                        ViewData["people"] = context.MissingPeople
                        .Where(
                        a => a.FoundCity == search.Ciry &&
                        a.FoundGovern == search.Govern &&
                        a.Gender == search.Gender)
                        .ToList();
                        return View("index");
                    }
                    //ABC
                    else if (search.Ciry != null && search.Gender != null && search.Date != null && search.Govern == null)
                    {
                        ViewData["people"] = context.MissingPeople
                        .Where(
                        a => a.FoundCity == search.Ciry &&
                        a.Date == search.Date && a.Gender == search.Gender)
                        .ToList();
                        return View("index");
                    }
                    //AB
                    else if (search.Ciry != null && search.Gender != null && search.Date == null && search.Govern == null)
                    {
                        ViewData["people"] = context.MissingPeople
                        .Where(
                        a => a.FoundCity == search.Ciry &&
                        a.Gender == search.Gender)
                        .ToList();
                        return View("index");
                    }
                    //AC
                    else if (search.Ciry != null && search.Gender == null && search.Date != null && search.Govern == null)
                    {
                        ViewData["people"] = context.MissingPeople
                        .Where(
                        a => a.FoundCity == search.Ciry &&
                        a.Date == search.Date)
                        .ToList();
                        return View("index");
                    }
                    //BC
                    else if (search.Ciry == null && search.Gender != null && search.Date != null && search.Govern == null)
                    {
                        ViewData["people"] = context.MissingPeople
                        .Where(
                        a =>
                        a.Date == search.Date && a.Gender == search.Gender)
                        .ToList();
                        return View("index");
                    }
                    //BD
                    else if (search.Ciry == null && search.Gender != null && search.Date == null && search.Govern != null)
                    {
                        ViewData["people"] = context.MissingPeople
                        .Where(
                        a =>
                        a.FoundGovern == search.Govern &&
                        a.Gender == search.Gender)
                        .ToList();
                        return View("index");
                    }
                    //A
                    else if (search.Ciry != null && search.Gender == null && search.Date == null && search.Govern == null)
                    {
                        ViewData["people"] = context.MissingPeople
                        .Where(
                        a => a.FoundCity == search.Ciry)
                        .ToList();
                        return View("index");
                    }
                    //B
                    else if (search.Ciry == null && search.Gender != null && search.Date == null && search.Govern == null)
                    {
                        ViewData["people"] = context.MissingPeople
                        .Where(
                        a =>
                        a.Gender == search.Gender)
                        .ToList();
                        return View("index");
                    }
                    //C
                    else
                    {
                        ViewData["people"] = context.MissingPeople
                        .Where(
                        a =>
                        a.Date == search.Date)
                        .ToList();
                        return View("index");
                    }
                }
                else
                {
                    int res=0;
                    string num = search.NameOrAge;
                    bool ok=int.TryParse(num, out res);
                    if(ok)
                    {
                        var context = new FindHimDbContext();
                        /*
                         *  A = City 
                         *  B = Gender
                         *  C = Date
                         *  D = Govern
                         */

       
                        if(search.Ciry==null && search.Date == null && search.Gender == null && search.Govern == null)
                        {
                            ViewData["people"] = context.MissingPeople
                                .Where(
                                a=>a.Age == res
                                )
                                .ToList();
                            return View("index");
                        }
                        //ABCD
                        else if (search.Ciry != null && search.Gender != null && search.Date != null && search.Govern != null)
                        {

                            ViewData["people"] = context.MissingPeople
                                .Where(
                                a => a.FoundCity == search.Ciry &&
                                a.FoundGovern == search.Govern &&a.Age==res&&
                                a.Date == search.Date && a.Gender == search.Gender)
                                .ToList();
                            return View("index");
                        }
                        //BCD
                        else if (search.Gender != null && search.Date != null && search.Govern != null && search.Ciry == null)
                        {
                            ViewData["people"] = context.MissingPeople
                            .Where(a =>
                            a.FoundGovern == search.Govern && a.Age == res &&
                            a.Date == search.Date && a.Gender == search.Gender)
                            .ToList();
                            return View("index");
                        }
                        //CD
                        else if (search.Date != null && search.Govern != null && search.Ciry == null && search.Gender == null)
                        {
                            ViewData["people"] = context.MissingPeople
                            .Where(
                            a =>
                            a.FoundGovern == search.Govern && a.Age == res &&
                            a.Date == search.Date)
                            .ToList();
                            return View("index");
                        }
                        //D
                        else if (search.Govern != null && search.Ciry == null && search.Gender == null && search.Date == null)
                        {
                            ViewData["people"] = context.MissingPeople
                            .Where(
                            a => a.Age == res &&
                            a.FoundGovern == search.Govern
                            )
                            .ToList();
                            return View("index");
                        }
                        //ACD
                        else if (search.Ciry != null && search.Date != null && search.Govern != null && search.Gender == null)
                        {
                            ViewData["people"] = context.MissingPeople
                            .Where(
                            a => a.FoundCity == search.Ciry && a.Age == res &&
                            a.FoundGovern == search.Govern &&
                            a.Date == search.Date)
                            .ToList();
                            return View("index");
                        }
                        //AD
                        else if (search.Ciry != null && search.Govern != null && search.Date == null && search.Gender == null)
                        {
                            ViewData["people"] = context.MissingPeople
                            .Where(
                            a => a.FoundCity == search.Ciry && a.Age == res &&
                            a.FoundGovern == search.Govern
                            )
                            .ToList();
                            return View("index");
                        }
                        //ABD
                        else if (search.Ciry != null && search.Gender != null && search.Govern != null && search.Date == null)
                        {
                            ViewData["people"] = context.MissingPeople
                            .Where(
                            a => a.FoundCity == search.Ciry &&
                            a.FoundGovern == search.Govern && a.Age == res &&
                            a.Gender == search.Gender)
                            .ToList();
                            return View("index");
                        }
                        //ABC
                        else if (search.Ciry != null && search.Gender != null && search.Date != null && search.Govern == null)
                        {
                            ViewData["people"] = context.MissingPeople
                            .Where(
                            a => a.FoundCity == search.Ciry && a.Age == res &&
                            a.Date == search.Date && a.Gender == search.Gender)
                            .ToList();
                            return View("index");
                        }
                        //AB
                        else if (search.Ciry != null && search.Gender != null && search.Date == null && search.Govern == null)
                        {
                            ViewData["people"] = context.MissingPeople
                            .Where(
                            a => a.FoundCity == search.Ciry && a.Age == res &&
                            a.Gender == search.Gender)
                            .ToList();
                            return View("index");
                        }
                        //AC
                        else if (search.Ciry != null && search.Gender == null && search.Date != null && search.Govern == null)
                        {
                            ViewData["people"] = context.MissingPeople
                            .Where(
                            a => a.FoundCity == search.Ciry && a.Age == res &&
                            a.Date == search.Date)
                            .ToList();
                            return View("index");
                        }
                        //BC
                        else if (search.Ciry == null && search.Gender != null && search.Date != null && search.Govern == null)
                        {
                            ViewData["people"] = context.MissingPeople
                            .Where(
                            a => a.Age == res &&
                            a.Date == search.Date && a.Gender == search.Gender)
                            .ToList();
                            return View("index");
                        }
                        //BD
                        else if (search.Ciry == null && search.Gender != null && search.Date == null && search.Govern != null)
                        {
                            ViewData["people"] = context.MissingPeople
                            .Where(
                            a => a.Age == res &&
                            a.FoundGovern == search.Govern &&
                            a.Gender == search.Gender)
                            .ToList();
                            return View("index");
                        }
                        //A
                        else if (search.Ciry != null && search.Gender == null && search.Date == null && search.Govern == null)
                        {
                            ViewData["people"] = context.MissingPeople
                            .Where(
                            a => a.Age == res && a.FoundCity == search.Ciry)
                            .ToList();
                            return View("index");
                        }
                        //B
                        else if (search.Ciry == null && search.Gender != null && search.Date == null && search.Govern == null)
                        {
                            ViewData["people"] = context.MissingPeople
                            .Where(
                            a => a.Age == res &&
                            a.Gender == search.Gender)
                            .ToList();
                            return View("index");
                        }
                        //C
                        else
                        {
                            ViewData["people"] = context.MissingPeople
                            .Where(
                            a => a.Age == res &&
                            a.Date == search.Date)
                            .ToList();
                            return View("index");
                        }
                    }
                    else
                    {
                        var context = new FindHimDbContext();
                        /*
                         *  A = City 
                         *  B = Gender
                         *  C = Date
                         *  D = Govern
                         */


                        if (search.Ciry == null && search.Date == null && search.Gender == null && search.Govern == null)
                        {
                            ViewData["people"] = context.MissingPeople
                                .Where(
                                a => a.Name == search.NameOrAge
                                )
                                .ToList();
                            return View("index");
                        }
                        //ABCD
                        else if (search.Ciry != null && search.Gender != null && search.Date != null && search.Govern != null)
                        {

                            ViewData["people"] = context.MissingPeople
                                .Where(
                                a => a.FoundCity == search.Ciry && a.Name == search.NameOrAge &&
                                a.FoundGovern == search.Govern &&
                                a.Date == search.Date && a.Gender == search.Gender)
                                .ToList();
                            return View("index");
                        }
                        //BCD
                        else if (search.Gender != null && search.Date != null && search.Govern != null && search.Ciry == null)
                        {
                            ViewData["people"] = context.MissingPeople
                            .Where(a =>
                            a.FoundGovern == search.Govern && a.Name == search.NameOrAge &&
                            a.Date == search.Date && a.Gender == search.Gender)
                            .ToList();
                            return View("index");
                        }
                        //CD
                        else if (search.Date != null && search.Govern != null && search.Ciry == null && search.Gender == null)
                        {
                            ViewData["people"] = context.MissingPeople
                            .Where(
                            a =>
                            a.FoundGovern == search.Govern && a.Name == search.NameOrAge &&
                            a.Date == search.Date)
                            .ToList();
                            return View("index");
                        }
                        //D
                        else if (search.Govern != null && search.Ciry == null && search.Gender == null && search.Date == null)
                        {
                            ViewData["people"] = context.MissingPeople
                            .Where(
                            a => a.Name == search.NameOrAge &&
                            a.FoundGovern == search.Govern
                            )
                            .ToList();
                            return View("index");
                        }
                        //ACD
                        else if (search.Ciry != null && search.Date != null && search.Govern != null && search.Gender == null)
                        {
                            ViewData["people"] = context.MissingPeople
                            .Where(
                            a => a.FoundCity == search.Ciry && a.Name == search.NameOrAge &&
                            a.FoundGovern == search.Govern &&
                            a.Date == search.Date)
                            .ToList();
                            return View("index");
                        }
                        //AD
                        else if (search.Ciry != null && search.Govern != null && search.Date == null && search.Gender == null)
                        {
                            ViewData["people"] = context.MissingPeople
                            .Where(
                            a => a.FoundCity == search.Ciry && a.Name == search.NameOrAge &&
                            a.FoundGovern == search.Govern
                            )
                            .ToList();
                            return View("index");
                        }
                        //ABD
                        else if (search.Ciry != null && search.Gender != null && search.Govern != null && search.Date == null)
                        {
                            ViewData["people"] = context.MissingPeople
                            .Where(
                            a => a.FoundCity == search.Ciry &&
                            a.FoundGovern == search.Govern && a.Name == search.NameOrAge &&
                            a.Gender == search.Gender)
                            .ToList();
                            return View("index");
                        }
                        //ABC
                        else if (search.Ciry != null && search.Gender != null && search.Date != null && search.Govern == null)
                        {
                            ViewData["people"] = context.MissingPeople
                            .Where(
                            a => a.FoundCity == search.Ciry && a.Name == search.NameOrAge &&
                            a.Date == search.Date && a.Gender == search.Gender)
                            .ToList();
                            return View("index");
                        }
                        //AB
                        else if (search.Ciry != null && search.Gender != null && search.Date == null && search.Govern == null)
                        {
                            ViewData["people"] = context.MissingPeople
                            .Where(
                            a => a.FoundCity == search.Ciry && a.Name == search.NameOrAge &&
                            a.Gender == search.Gender)
                            .ToList();
                            return View("index");
                        }
                        //AC
                        else if (search.Ciry != null && search.Gender == null && search.Date != null && search.Govern == null)
                        {
                            ViewData["people"] = context.MissingPeople
                            .Where(
                            a => a.FoundCity == search.Ciry && a.Name == search.NameOrAge &&
                            a.Date == search.Date)
                            .ToList();
                            return View("index");
                        }
                        //BC
                        else if (search.Ciry == null && search.Gender != null && search.Date != null && search.Govern == null)
                        {
                            ViewData["people"] = context.MissingPeople
                            .Where(
                            a => a.Name == search.NameOrAge &&
                            a.Date == search.Date && a.Gender == search.Gender)
                            .ToList();
                            return View("index");
                        }
                        //BD
                        else if (search.Ciry == null && search.Gender != null && search.Date == null && search.Govern != null)
                        {
                            ViewData["people"] = context.MissingPeople
                            .Where(
                            a => a.Name == search.NameOrAge &&
                            a.FoundGovern == search.Govern &&
                            a.Gender == search.Gender)
                            .ToList();
                            return View("index");
                        }
                        //A
                        else if (search.Ciry != null && search.Gender == null && search.Date == null && search.Govern == null)
                        {
                            ViewData["people"] = context.MissingPeople
                            .Where(
                            a => a.Name == search.NameOrAge && a.FoundCity == search.Ciry)
                            .ToList();
                            return View("index");
                        }
                        //B
                        else if (search.Ciry == null && search.Gender != null && search.Date == null && search.Govern == null)
                        {
                            ViewData["people"] = context.MissingPeople
                            .Where(
                            a => a.Name == search.NameOrAge &&
                            a.Gender == search.Gender)
                            .ToList();
                            return View("index");
                        }
                        //C
                        else
                        {
                            ViewData["people"] = context.MissingPeople
                            .Where(
                            a => a.Name == search.NameOrAge &&
                            a.Date == search.Date)
                            .ToList();
                            return View("index");
                        }
                    }
                }
            }
        }
        public IActionResult Delete()
        {
            var context = new FindHimDbContext();
            ViewData["people"] = context.MissingPeople.ToList();
            return View("index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}