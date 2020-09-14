using MyApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MyApp.DB.DBOperations
{
    public class EmployeeRespository
    {
       
        public int AddEmployee(EmployeeModel employeeModel)
        {
            using (var context=new EmployeeEntities())
            {
                Employee emp = new Employee()
                {
                    Name=employeeModel.Name,
                    Position = employeeModel.Position,
                    Age=employeeModel.Age,
                    Salary=employeeModel.Salary
                    
            };
                if(employeeModel.Address!=null)
                {
                    emp.Address = new Address()
                    {
                        City = employeeModel.Address.City,
                        District = employeeModel.Address.District,
                        State = employeeModel.Address.State,
                        PostalCode = employeeModel.Address.PostalCode
                    };
                }
                if(employeeModel.Designation!=null)
                {
                    emp.Designation = new Designation()
                    {
                        Name = employeeModel.Designation.Name,
                        JoiningDate = employeeModel.Designation.JoiningDate,
                        TotalYears = employeeModel.Designation.TotalYears
                    };
                }
                context.Employees.Add(emp);
                context.SaveChanges();

                return emp.ID;
            }
        }

        public List<EmployeeModel> GetAllEmployees()
        {
            using (var context = new EmployeeEntities())
            {
                var result = context.Employees.Select(x=>new EmployeeModel() 
                { 
                ID=x.ID,
                Name=x.Name,
                Position=x.Position,
                Salary=x.Salary,
                Age=x.Age,

                Address=new AddressModel()
                {
                    ID=x.Address.ID,
                    City=x.Address.City,
                    State=x.Address.State,
                    District=x.Address.District,
                    PostalCode=x.Address.PostalCode
                },
                Designation=new DesignationModel()
                {
                    ID=x.Designation.ID,
                    Name=x.Designation.Name,
                    JoiningDate=x.Designation.JoiningDate,
                    TotalYears=x.Designation.TotalYears
                }
                
                }).ToList();
                return result;
            }
            
        }

        public EmployeeModel GetEmployee(int id)
        {
            using (var context = new EmployeeEntities())
            {
                var result = context.Employees
                    .Where(x => x.ID.Equals(id))
                    .Select(x => new EmployeeModel()
                    {
                        ID = x.ID,
                        Name = x.Name,
                        Position = x.Position,
                        Salary = x.Salary,
                        Age = x.Age,
                        AddressId=x.AddressId,

                        Address = new AddressModel()
                        {
                            ID = x.Address.ID,
                            City = x.Address.City,
                            State = x.Address.State,
                            District = x.Address.District,
                            PostalCode = x.Address.PostalCode
                        },
                        Designation=new DesignationModel()
                        {
                            ID=x.Designation.ID,
                            Name=x.Designation.Name,
                            JoiningDate=x.Designation.JoiningDate,
                            TotalYears=x.Designation.TotalYears
                        }
                        

                    }).FirstOrDefault();
                return result;
            }

        }

        public bool UpdateEmployee(int id, EmployeeModel employeeModel)
        {
            using(var context=new EmployeeEntities())
            {
                // var employeeData = context.Employees.FirstOrDefault(x => x.ID.Equals(id));
                var employeeData = new Employee();
                if(employeeData!=null)
                {

                    employeeData.Name = employeeModel.Name;
                    employeeData.Position = employeeModel.Position;
                    employeeData.Age = employeeModel.Age;
                    employeeData.Salary = employeeModel.Salary;
                    employeeData.AddressId = employeeModel.AddressId;

                    if (employeeData.Address != null)
                    {

                        employeeData.Address.State = employeeData.Address.State;
                        employeeData.Address.District = employeeData.Address.District;
                        employeeData.Address.City = employeeData.Address.City;
                        employeeData.Address.PostalCode = employeeData.Address.PostalCode;

                    }
                    if (employeeData.Designation != null)
                    {

                        employeeData.Designation.Name = employeeData.Designation.Name;
                        employeeData.Designation.JoiningDate = employeeData.Designation.JoiningDate;
                        employeeData.Designation.TotalYears = employeeData.Designation.TotalYears;
                    }
                }
                
                context.Entry(employeeData).State = System.Data.Entity.EntityState.Modified;
                //this is the feature of entity framework which reduce the hits
                
                context.SaveChanges();
                return true;
            }
        }

        public bool DeleteEmployee(int id)
        {
            using (var context=new EmployeeEntities())
            {

                var emp = new Employee()
                {
                    ID = id
                };
                context.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
                return false;
            }
        }
      
        public List<EmployeeModel> SearchEmployee(string searchTxt)
        {
            using (var context = new EmployeeEntities())
            {
                var result = context.Employees
                    .Where(x=>x.Name.Equals(searchTxt))
                    .Select(x => new EmployeeModel()
                {
                    ID = x.ID,
                    Name = x.Name,
                    Position = x.Position,
                    Salary = x.Salary,
                    Age = x.Age,

                    Address = new AddressModel()
                    {
                        ID = x.Address.ID,
                        City = x.Address.City,
                        State = x.Address.State,
                        District = x.Address.District,
                        PostalCode = x.Address.PostalCode
                    }

                }).ToList();
                return result;
            }

        }
    }
}
