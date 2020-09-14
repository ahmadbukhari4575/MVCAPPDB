
using System.ComponentModel.DataAnnotations;

namespace MyApp.Models
{
    public class EmployeeModel
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
       
        public int Age { get; set; }
        [Required]
        public double Salary { get; set; }
        public int? AddressId { get; set; }
        public int? DesignationId { get; set; }
        
        public DesignationModel Designation { get; set; }

        public AddressModel Address { get; set; }
    }
}
