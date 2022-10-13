using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSProject.Models
{
    public class VmDepartment
    {
        [Display(Name = "Department ID")]
        public int DepartmentId { get; set; }
        [Display(Name = "DepartmentName")]
        [Required(ErrorMessage = "Please Enter DepartmentName ")]
        public string DepartmentName { get; set; }
        [Display(Name = "BranchId")]
        [Required(ErrorMessage = "Please Enter BranchId ")]
        public int? BranchId { get; set; }
    }
}
