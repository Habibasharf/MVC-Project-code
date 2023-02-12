using Microsoft.AspNetCore.Mvc;
using MVCNew_project.Models;
using MVCNew_project.Services;

namespace MVCNew_project.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartment dept;
        public DepartmentController(IDepartment _dept)
        {
            dept = _dept;
        }

        public ActionResult Index()
        {
            List<Department> model = dept.GetAll();
            return View(model);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return BadRequest("You must enter id ");
            var model = dept.Find(id.Value);

            if (model == null)
                return NotFound();
            return View(model);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return BadRequest("You must enter id ");
            var model = dept.Find(id.Value);

            if (model == null)
                return NotFound();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(Department dt)
        {
            try
            {
                dept.Add(dt);
                return View("Index", dept.GetAll());

            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Edit(Department d)
        {
            dept.update(d);
            return View("Index", dept.GetAll());

        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest("You must enter id ");
            dept.DeleteById(id.Value);
            return View("index", dept.GetAll());
        }
    }
}
