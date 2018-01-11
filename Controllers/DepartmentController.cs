using RepositoryWithMVC.Models;
using RepositoryWithMVC.Repository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace RepositoryWithMVC.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentRepository _iDepartmentRepository;
        public DepartmentController()
        {
            _iDepartmentRepository = new DepartmentRepository(new EmployeeContext());
        }

        public DepartmentController(IDepartmentRepository iEmployeeRepository)
        {
            _iDepartmentRepository = iEmployeeRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<Department> model = _iDepartmentRepository.GetAllDepartment();
            return View(model);
        }
    }
}