using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project1.Models;
using Project1.ViewModels;
using System.Security.Claims;

namespace Project1.Controllers
{
    public class MissingPeopleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddPerson() 
        {
            return View();
        }
        public IActionResult SavedPerson(_MissingPerson person)
        {
            var context = new FindHimDbContext();
            byte[] imageBytes;
			using (var memoryStream = new MemoryStream())
			{
				person.Image.CopyTo(memoryStream);
				imageBytes = memoryStream.ToArray();

				// Now you have the imageBytes array containing the image data as bytes.
				// You can use it as needed (e.g., store in the database).
			}

            //var Id=context.Users.Where(a=>a.Email==User.Claims.Where(a=>a))
            var account = User.FindFirstValue(ClaimTypes.Email);
            var userLogin = context.Users.Where(a => a.Email == account).FirstOrDefault();
            if(person.Name == null)
            {
                person.Name = "UnKnown";
            }
            var newPerson = new MissingPerson()
            {
                Name = person.Name,
                Phone = person.Phone,
                Age = person.Age,
				Address_Govern = person.Address_Govern,
				Address_City = person.Address_City,
                Date = person.Date,
                FoundCity = person.FoundCity,
                FoundGovern = person.FoundGovern,
                Gender = person.Gender,
                Image = imageBytes,
                UserId = userLogin.Id
            };
            context.MissingPeople.Add(newPerson);
            context.SaveChanges();
            return RedirectToAction("People", "MissingPeople");
        }
        public IActionResult People()
        {
            var context = new FindHimDbContext();
            var account = User.FindFirstValue(ClaimTypes.Email);
            var userLogin=context.Users.Where(a=>a.Email == account).Select(a=>a.Id).FirstOrDefault();
            var _people=context.MissingPeople.Where(a=>a.UserId==userLogin).ToList();
            ViewData["_people"]= _people;
            return View();
        }
        public IActionResult Person(int id)
        {
            var context = new FindHimDbContext();
            var information = context.MissingPeople
            .Include(a => a.User)
            .Where(a => a.Id == id)
            .Select(b => new
            {
                b.Name,
                b.Date,
                b.Age,
                b.Gender,
                b.Address_City,
                b.Address_Govern,
                b.FoundCity,
                b.FoundGovern,
                b.Phone,
                b.Image,
                UserName = b.User != null ? b.User.Name : null // Handle null User reference
            })
            .FirstOrDefault();
            Information info = new Information
            {
                Name = information.Name,
                Date=information.Date,
                Age=information.Age,
                Gender=information.Gender,
				FoundGovern = information.FoundGovern,
				Address_City =information.Address_City,
                Phone=information.Phone,
                Address_Govern=information.Address_Govern,
                FoundCity=information.FoundCity,
                UserName=information.UserName,
                Image = information.Image
            };
            return View(info);
        }
        public IActionResult Delete(int id)
        {
            var context = new FindHimDbContext();
            var temp = context.MissingPeople.Where(a => a.Id == id).FirstOrDefault();
            context.MissingPeople.Remove(temp);
            context.SaveChanges();
            return RedirectToAction("People", "MissingPeople");
        }
    }
}
