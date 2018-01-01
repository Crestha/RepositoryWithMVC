using RepositoryWithMVC.Models;
using RepositoryWithMVC.Repository;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace RepositoryWithMVC.Controllers
{
    //When we instantiate the repository in the controller, we'll use the interface so that the controller will accept a reference to any object that implements the repository interface. 
    public class EmployeeController : Controller
    {
        //The controller now declares a class variable for an object that implements the IEmployeeRepository interface instead of the context class:
        private IEmployeeRepository _iEmployeeRepository;

        //The default (parameterless) constructor creates a new context instance
        public EmployeeController()
        {
            _iEmployeeRepository = new EmployeeRepository(new EmployeeContext());
        }

        //optional constructor allows the caller to pass in a context instance.
        public EmployeeController(IEmployeeRepository iEmployeeRepository)
        {
            _iEmployeeRepository = iEmployeeRepository;
        }
        
        // GET: /RepositoryEmployee/Index
        public ActionResult Index(int? departmentId)
        {
            if (departmentId != null)
            {
                var model = _iEmployeeRepository.GetEmployeeByDepartment(departmentId);
                return View(model);
            }
            else
            {
                var model = _iEmployeeRepository.GetAllEmployees();
                return View(model);
            }
        }

        //Create
        // GET: /RepositoryEmployee/AddEmployee
        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEmployee(Employee employee, HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Photo != null)
                    {
                        if (Photo.ContentLength > 0)
                        {
                            //for checking uploaded file is image or not
                            if (Path.GetExtension(Photo.FileName).ToLower() == ".jpg"
                                || Path.GetExtension(Photo.FileName).ToLower() == ".png"
                                || Path.GetExtension(Photo.FileName).ToLower() == ".gif"
                                || Path.GetExtension(Photo.FileName).ToLower() == ".jpeg"
                                )
                            {
                                string fileName = Path.GetFileName(Photo.FileName);

                                var pathToStoreImageInsideProjectFolder = Path.Combine(Server.MapPath("~/Photos"), fileName);
                                Photo.SaveAs(pathToStoreImageInsideProjectFolder);

                                employee.Photo = "~/Photos/" + fileName;

                                _iEmployeeRepository.InsertEmployee(employee);
                                _iEmployeeRepository.Save();
                                return RedirectToAction("Index", "Employee");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return View(employee);
        }

        // GET: /RepositoryEmployee/Details/1
        public ActionResult EmployeeDetails(int employeeId)
        {
            Employee model = _iEmployeeRepository.GetEmployeeById(employeeId);
            return View(model);
        }

        // GET: /RepositoryEmployee/EditEmployee/1
        public ActionResult EditEmployee(int employeeId)
        {
            Employee model = _iEmployeeRepository.GetEmployeeById(employeeId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmployee(Employee employee, HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Photo != null)
                    {
                        if (Photo.ContentLength > 0)
                        {
                            //for checking uploaded file is image or not
                            if (Path.GetExtension(Photo.FileName).ToLower() == ".jpg"
                                || Path.GetExtension(Photo.FileName).ToLower() == ".png"
                                || Path.GetExtension(Photo.FileName).ToLower() == ".gif"
                                || Path.GetExtension(Photo.FileName).ToLower() == ".jpeg"
                                )
                            {
                                string fileName = Path.GetFileName(Photo.FileName);

                                var pathToStoreImageInsideProjectFolder = Path.Combine(Server.MapPath("~/Photos"), fileName);
                                Photo.SaveAs(pathToStoreImageInsideProjectFolder);

                                employee.Photo = "~/Photos/" + fileName;

                                _iEmployeeRepository.UpdateEmployee(employee);
                                _iEmployeeRepository.Save();
                                return RedirectToAction("Index", "Employee");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return View(employee);
        }

        // GET: /RepositoryEmployee/DeleteEmployee/1
        public ActionResult DeleteEmployee(int employeeId)
        {
            Employee model = _iEmployeeRepository.GetEmployeeById(employeeId);
            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteEmployee(Employee employee)
        {
            _iEmployeeRepository.DeleteEmployee(employee.EmployeeId);
            _iEmployeeRepository.Save();
            return RedirectToAction("Index", "Employee");
        }

        protected override void Dispose(bool disposing)
        {
            //the Dispose method now disposes the repository instead of the context:
            _iEmployeeRepository.Dispose();
            base.Dispose(disposing);
        }

    }
}