using RepositoryWithMVC.model;
using RepositoryWithMVC.repository;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RepositoryWithMVC.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentRepository _DepartmentRepository;

        public DepartmentController() : this(null)
        {
        }

        public DepartmentController(IDepartmentRepository departRepo)
        {
            _DepartmentRepository = departRepo ?? new DepartmentRepository();
        }

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<Department> model = _DepartmentRepository.GetAllDepartment();
            return View(model);
        }
    }
}
