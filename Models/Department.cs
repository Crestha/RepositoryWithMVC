using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryWithMVC.Models
{
    [Table("tblDepartments")]
    public class Department
    {
        public int DepartmentId { get; set; }

        [Required(ErrorMessage ="Department Name is Required")]
        [Display(Name ="Department Name")]
        public string DepartmentName { get; set; }

        //Department can have multiple employees
        public List<Employee> Employees { get; set; }
    }

}