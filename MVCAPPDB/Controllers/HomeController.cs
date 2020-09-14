using MyApp.DB.DBOperations;
using MyApp.Models;
using System.Web.Mvc;

namespace MVCAPPDB.Controllers
{
    public class HomeController : Controller
    {
        EmployeeRespository repository = null;
        public HomeController()
        {
            repository =new  EmployeeRespository();
        }
       [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeeModel employeeModel)
        {
            if(ModelState.IsValid)
            {
                int id=repository.AddEmployee(employeeModel);
                
                if(id>0)
                {
                    ModelState.Clear();
                   
                    return RedirectToAction("GetAllEmployee");
                   
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult GetAllEmployee()
        {
            var data = repository.GetAllEmployees();
            return View(data);
        }
        [HttpGet]
        public ActionResult GetEmployee(int id)
        {
            var data = repository.GetEmployee(id);
            return View(data);
        }
        [HttpGet]
        public ActionResult EditEmployee(int id)
        {
            var data = repository.GetEmployee(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult EditEmployee(EmployeeModel employeeModel)
        {
            if(ModelState.IsValid)
            {
                repository.UpdateEmployee(employeeModel.ID,employeeModel);
                
                    return RedirectToAction("GetAllEmployee");
                
                
            }
            return View();
        }
        public ActionResult DeleteEmployee(int id)
        {
           
            var data = repository.GetEmployee(id);
           
           
            return View(data);
        }

        [HttpPost, ActionName("DeleteEmployee")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
          
                repository.DeleteEmployee(id);
                return RedirectToAction("GetAllEmployee");
           

        }
     
        public ActionResult SearchUser(string name)
        {
            var data = repository.SearchEmployee(name);
            return View(data);
        }
    }


}