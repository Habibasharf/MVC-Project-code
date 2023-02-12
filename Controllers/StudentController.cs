using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCNew_project.Models;
using System.Net;
using System.Reflection;
using System.IO;
using MVCNew_project.Services;

namespace MVCNew_project.Controllers
{
    public class StudentController : Controller
    {
        // GET: StudentController
        IStudent std;
        public StudentController(IStudent _std)
        {
            std = _std;
        }

        public ActionResult Index()
        {
            List<Student> model = std.GetAll();
            return View(model);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return BadRequest("You must enter id ");
            var model = std.Find(id.Value);
           
            if (model == null)
                return NotFound();
            return View(model);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit( int? id)
        {
            if (id == null)
                return BadRequest("You must enter id ");
            var model = std.Find(id.Value);

            if (model == null)
                return NotFound();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(Student st, IFormFile stdimg)
        {
            if (ModelState.IsValid)
            {

                string imgname = st.ID.ToString() + "." + stdimg.FileName.Split(".").Last();
                if (stdimg != null)
                {
                    using (var item = System.IO.File.Create("wwwroot/images/" + imgname))
                    {
                        stdimg.CopyTo(item);
                    };
                }
                st.ImageName = imgname;
                std.Add(st);
                return View("Index", std.GetAll());

            }
            else
            {
                return View(st);
            }
        }
        public ActionResult Download(int? id)
        {
            var model = std.Find(id.Value);
            return File("images/" + model.ImageName, "image/jpg", model.Name + "." + "jpg");
        }
        [HttpPost]
        public ActionResult Edit(Student s)
        {
            std.update(s);
            return View("Index", std.GetAll());

        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest("You must enter id ");
             std.DeleteById(id.Value);
            return View("index", std.GetAll());
        }
    }
}
