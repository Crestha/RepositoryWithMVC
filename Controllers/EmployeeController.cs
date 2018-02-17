using RepositoryWithMVC.model;
using RepositoryWithMVC.repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace RepositoryWithMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _EmployeeRepository;

        public EmployeeController() : this(null)
        {
        }
        
        public EmployeeController(IEmployeeRepository empRepo)
        {
            _EmployeeRepository = empRepo ?? new EmployeeRepository();
        }

        [HttpGet]
        public ActionResult Index(int? departmentId)
        {
            if (departmentId != null)
            {
                IEnumerable<Employee> model = _EmployeeRepository.GetEmployeeByDepartment(departmentId);
                return View(model);
            }
            else
            {
                IEnumerable<Employee> model = _EmployeeRepository.GetAllEmployees();
                return View(model);
            }
        }
        
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
                            // For checking uploaded file is image or not.
                            if (Path.GetExtension(Photo.FileName).ToLower() == ".jpg"
                                || Path.GetExtension(Photo.FileName).ToLower() == ".png"
                                || Path.GetExtension(Photo.FileName).ToLower() == ".gif"
                                || Path.GetExtension(Photo.FileName).ToLower() == ".jpeg"
                                )
                            {
                                string fileName = Path.GetFileName(Photo.FileName);

                                string pathToStoreImageInsideProjectFolder = Path.Combine(Server.MapPath("~/Photos"), fileName);
                                Photo.SaveAs(pathToStoreImageInsideProjectFolder);

                                employee.Photo = "~/Photos/" + fileName;

                                _EmployeeRepository.InsertEmployee(employee);
                                _EmployeeRepository.Save();
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

        [HttpGet]
        public ActionResult EmployeeDetails(int employeeId)
        {
            Employee model = _EmployeeRepository.GetEmployeeById(employeeId);
            return View(model);
        }

        [HttpGet]
        public ActionResult EditEmployee(int employeeId)
        {
            Employee model = _EmployeeRepository.GetEmployeeById(employeeId);
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
                            if (Path.GetExtension(Photo.FileName).ToLower() == ".jpg"
                                || Path.GetExtension(Photo.FileName).ToLower() == ".png"
                                || Path.GetExtension(Photo.FileName).ToLower() == ".gif"
                                || Path.GetExtension(Photo.FileName).ToLower() == ".jpeg"
                                )
                            {
                                string fileName = Path.GetFileName(Photo.FileName);

                                string pathToStoreImageInsideProjectFolder = Path.Combine(Server.MapPath("~/Photos"), fileName);
                                Photo.SaveAs(pathToStoreImageInsideProjectFolder);

                                employee.Photo = "~/Photos/" + fileName;

                                _EmployeeRepository.UpdateEmployee(employee);
                                _EmployeeRepository.Save();
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

        [HttpGet]
        public ActionResult DeleteEmployee(int employeeId)
        {
            Employee model = _EmployeeRepository.GetEmployeeById(employeeId);
            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteEmployee(Employee employee)
        {
            _EmployeeRepository.DeleteEmployee(employee.EmployeeId);
            _EmployeeRepository.Save();
            return RedirectToAction("Index", "Employee");
        }
    }
}
