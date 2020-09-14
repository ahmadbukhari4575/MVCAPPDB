using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Models
{
    public class DesignationModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime JoiningDate { get; set; }
        [DataType(DataType.Text)]
        public decimal TotalYears { get; set; }
    }
}
