using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryWithMVC.model
{
    [Table("tblDepartments")]
    public class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        // Primitive properties
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Department Name is Required")]
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }

        // Navigation properties -Department can have multiple employees
        public ICollection<Employee> Employees { get; set; }
    }

}