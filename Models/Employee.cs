using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryWithMVC.Models
{
    [Table("tblEmployees")]
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Employee Name is Required")]
        [Display(Name = "Employee Name")]
        [StringLength(10, MinimumLength = 3)]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-za-z]+))$", ErrorMessage = "Please enter lower and upper case alphabets only")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Gender is Required")]
        public string Gender { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date), Required(ErrorMessage = "Date of Birth is Required")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]//:MM/dd/yyyy}",
        public DateTime? DateOfBirth { get; set; }

        //[Required(ErrorMessage = "Age is Required")]
        //[Range(1,100)]
        //public int Age { get; set; }

        [Display(Name = "Full Address"), Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }

        [Display(Name = "Phone Number"), Required(ErrorMessage = "Phone Number is Required")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[2-9]\d{2}-\d{3}-\d{4}$", ErrorMessage = "Invalid Phone Number. Hint: 000-000-0000")]
        public string PhoneNumber { get; set; }

        [Required]
        public string Photo { get; set; }

        [Required]
        public string AlternateText { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [Required]
        [Range(5000, 100000, ErrorMessage = "Salary should be in the range of 5000 to 100000")]
        public int Salary { get; set; }

        //Navigation property
        [ForeignKey(nameof(DepartmentId))]
        public Department Department { get; set; }
    }
}



