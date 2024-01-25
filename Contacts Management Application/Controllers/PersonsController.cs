using Contacts_Management_Application.Models.Context;
using Contacts_Management_Application.Models.Entity;
using Contacts_Management_Application.Models.PersonsDetailViewModel;
using Contacts_Management_Application.Models.PersonUpdateViewModel;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Contacts_Management_Application.Controllers
{
    public class PersonsController : Controller
    {
        ContactContext db = new ContactContext();
        // GET: Persons
        
        public ActionResult Index()
        {
            var persons = db.Persons.ToList();
            return View(persons);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> Index(string Search)
        {
            ViewData["Persons"] = Search;

            var xsearch = from x in db.Persons select x;
            if (!string.IsNullOrEmpty(Search))
            {
                xsearch = xsearch.Where(x => x.Name.Contains(Search) || x.SurName.Contains(Search));
            }
            return View(await xsearch.AsNoTracking().ToListAsync());
        }

        [HttpPost]
        public ActionResult Add(Persons persons)
        {
            try
            {
                db.Persons.Add(persons);
                db.SaveChanges();
                TempData["Successful"] = "Successful Registration";
            }
            catch (Exception)
            {
                TempData["Mistake"] = "Registration Failed! Please Try Again";
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var persons = db.Persons.Find(id);
            if (persons == null)
            {
                TempData["Mistake"] = "No Records Found to Update!";
                return RedirectToAction("Index");
            }

            var model = new PersonsUpdateViewModel
            {
                Persons = persons
            };

            ViewBag.Persons = new SelectList(db.Persons.ToList(), "Id", "");

            return View(model);
        }
        [HttpPost]
        public ActionResult Update(Persons persons)
        {
            var OldPerson = db.Persons.Find(persons.Id);
            if (OldPerson == null)
            {
                TempData["Mistake"] = "No Records Found to Update!";
                return RedirectToAction("Index");
            }

            OldPerson.Name = persons.Name;
            OldPerson.SurName = persons.SurName;
            OldPerson.Email = persons.Email;
            OldPerson.Phone = persons.Phone;

            db.SaveChanges();
            TempData["Successful"] = "Update Successful";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var Persons = db.Persons.Find(id);
            if (Persons == null)
            {
                TempData["Mistake"] = "Person Not Found!";
                return RedirectToAction("Index");
            }
            var model = new PersonsDetailViewModel
            {
                Persons = Persons
            };
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var Persons = db.Persons.Find(id);

            if (Persons == null)
            {
                TempData["Mistake"] = "Person Not Found!";
                return RedirectToAction("Index");
            }
            db.Persons.Remove(Persons);
            db.SaveChanges();
            TempData["Successful"] = "Delete Successful";
            return RedirectToAction("Index");
        }
    }
}