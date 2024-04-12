using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UI_layer.Models;
using FHP_BL;
using FHP_VO;
using FHP_DL;
using System;

namespace UI_layer.Controllers
{
    public class HomeController : Controller
    {
        // private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger,)
        //{
        //    _logger = logger;
        //}
        private readonly DBhelper _dbHelper;
        private readonly cls_FileHandling _fileHandling;


        public HomeController(DBhelper dbHelper, cls_FileHandling fileHandling)
        {
            _dbHelper = dbHelper;
            _fileHandling = fileHandling;

        }

        // private readonly cls_FileHandling _fileHandling;

        //public HomeController(DBhelper dbHelper, cls_FileHandling fileHandling) : this(dbHelper)
        // {
        //     _fileHandling = fileHandling;
        // }


        public IActionResult LoginPage()
        {

            return View();
        }

        public IActionResult _EmployeeListPartial()
        {

            return View();
        }
        public IActionResult AboutUs()
        {

            return View();
        }

        [HttpPost]
        public IActionResult DeleteEmployees(List<int> ids)
        {
            try
            {
                // Delete employees from database
                cls_FileHandling.DeleteEmployees(ids);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                // Log exception
                return Json(new { success = false });
            }
        }


        [HttpPost]
        public IActionResult LoginPage(string username, string password)
        {
            bool isAuthenticated = _dbHelper.AuthenticateUser(username, password);

            if (isAuthenticated)
            {
                // Authentication successful
                return RedirectToAction("MainPage");
            }
            else
            {
                // Authentication failed
                ViewBag.ErrorMessage = "Invalid username or password";
                return View();
            }
        }
        public IActionResult MainPage()
        {
            return View("MainPage");
        }

        //public IActionResult MainPage()
        //{
        //    List<cls_EmployeeProp> employees = cls_FileHandling.GetAllEmployee();
        //    return View(employees);
        //}


        [HttpGet]
        public IActionResult MainPage(string sortOrder, string sortBy, string searchString)
        {
            // Setting sort parameters for the view
            ViewData["SNoSortParam"] = string.IsNullOrEmpty(sortOrder) || sortBy != "SerialNo" ? "sno_desc" : "";
            ViewData["PrefixSortParam"] = sortBy == "Prefix" ? "prefix_desc" : "Prefix";
            ViewData["FirstNameSortParam"] = sortBy == "FirstName" ? "firstname_desc" : "FirstName";
            ViewData["MiddleNameSortParam"] = sortBy == "MiddleName" ? "middlename_desc" : "MiddleName";
            ViewData["LastNameSortParam"] = sortBy == "LastName" ? "lastname_desc" : "LastName";
            ViewData["QualificationSortParam"] = sortBy == "Qualification" ? "qualification_desc" : "Qualification";
            ViewData["CurrentAddressSortParam"] = sortBy == "CurrentAddress" ? "currentaddress_desc" : "CurrentAddress";
            ViewData["CurrentCompanySortParam"] = sortBy == "CurrentCompany" ? "currentcompany_desc" : "CurrentCompany";
            ViewData["DOBSortParam"] = sortBy == "DOB" ? "dob_desc" : "DOB";
            ViewData["JoiningDateSortParam"] = sortBy == "JoiningDate" ? "joiningdate_desc" : "JoiningDate";

            var employees = cls_FileHandling.GetAllEmployee();

            if (!string.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(e => e.FirstName.Contains(searchString)
                                               || e.LastName.Contains(searchString)
                                               || e.CurrentCompany.Contains(searchString)).ToList();
            }

            switch (sortOrder)
            {
                case "sno_desc":
                    employees = employees.OrderByDescending(e => e.SerialNo).ToList();
                    break;
                case "Prefix":
                    employees = employees.OrderBy(e => e.Prefix).ToList();
                    break;
                case "prefix_desc":
                    employees = employees.OrderByDescending(e => e.Prefix).ToList();
                    break;
                case "FirstName":
                    employees = employees.OrderBy(e => e.FirstName).ToList();
                    break;
                case "firstname_desc":
                    employees = employees.OrderByDescending(e => e.FirstName).ToList();
                    break;
                case "MiddleName":
                    employees = employees.OrderBy(e => e.MiddleName).ToList();
                    break;
                case "middlename_desc":
                    employees = employees.OrderByDescending(e => e.MiddleName).ToList();
                    break;
                case "LastName":
                    employees = employees.OrderBy(e => e.LastName).ToList();
                    break;
                case "lastname_desc":
                    employees = employees.OrderByDescending(e => e.LastName).ToList();
                    break;
                case "Qualification":
                    employees = employees.OrderBy(e => e.Education).ToList();
                    break;
                case "qualification_desc":
                    employees = employees.OrderByDescending(e => e.Education).ToList();
                    break;
                case "CurrentAddress":
                    employees = employees.OrderBy(e => e.CurrentAddress).ToList();
                    break;
                case "currentaddress_desc":
                    employees = employees.OrderByDescending(e => e.CurrentAddress).ToList();
                    break;
                case "CurrentCompany":
                    employees = employees.OrderBy(e => e.CurrentCompany).ToList();
                    break;
                case "currentcompany_desc":
                    employees = employees.OrderByDescending(e => e.CurrentCompany).ToList();
                    break;
                case "DOB":
                    employees = employees.OrderBy(e => e.DOB).ToList();
                    break;
                case "dob_desc":
                    employees = employees.OrderByDescending(e => e.DOB).ToList();
                    break;
                case "JoiningDate":
                    employees = employees.OrderBy(e => e.JoiningDate).ToList();
                    break;
                case "joiningdate_desc":
                    employees = employees.OrderByDescending(e => e.JoiningDate).ToList();
                    break;
                default:
                    employees = employees.OrderBy(e => e.SerialNo).ToList();
                    break;
            }

            return PartialView("MainPage", employees);
        }




        



        public IActionResult EditAdd()
        {
            return View();

        }
        [HttpPost]
        public IActionResult EditAdd(cls_EmployeeProp employee, string action)
        {
           
                try

                {
                    cls_EmployeeProp employeeProp = new cls_EmployeeProp
                    {
                        SerialNo = employee.SerialNo,
                        Prefix = employee.Prefix,
                        FirstName = employee.FirstName,
                        MiddleName = employee.MiddleName,
                        LastName = employee.LastName,
                        Education = employee.Education,
                        JoiningDate = employee.JoiningDate,
                        CurrentCompany = employee.CurrentCompany,
                        CurrentAddress = employee.CurrentAddress,
                        DOB = employee.DOB
                    };


                if (action == "Add" && ModelState.IsValid)
                {
                    
                    cls_FileHandling.AddEmployeeInfoIntoFile(employee);
                    TempData["SuccessMessage"] = "Employee added successfully.";

                    List<cls_EmployeeProp> employees = cls_FileHandling.GetAllEmployee();

                    // Using the DL method

                     return RedirectToAction("MainPage", "Home");

                }
                return View(employee);

                //return View("EditAdd",employee);
                // Assuming Index is your main page
            }




            catch (Exception ex)
                {
                    // Handle exception, maybe return to an error page or show a message
                    return RedirectToAction("Error");
                }
            }

        public IActionResult EditDetails(int id)
        {
            var employee = cls_FileHandling.GetEmployeeById(id);
            return View(employee);
            }


            [HttpPost]
            public IActionResult EditDetails(cls_EmployeeProp employee)
            {
                if (ModelState.IsValid)
                {
                    // Update the employee details
                    cls_FileHandling.UpdateEntry(employee);
                    return RedirectToAction("MainPage"); // Redirect to the main page after successful update
                }
                return View(employee); // Return the view with validation errors
            }




            // [HttpPost]
            //public IActionResult EditDetails(List<int> selectedEmployees)
            //{
            //    if (selectedEmployees == null || selectedEmployees.Count == 0)
            //    {
            //        TempData["ErrorMessage"] = "Please select at least one employee.";
            //        return RedirectToAction("MainPage");
            //    }

            //    // You can now update the selected employees in your data layer
            //    foreach (var employeeId in selectedEmployees)
            //    {
            //        var employee = cls_FileHandling.GetEmployeeById(employeeId);
            //        if (employee != null)
            //        {
            //            // Update the employee details
            //            cls_FileHandling.UpdateEntry(employee);
            //        }
            //    }

            //    TempData["SuccessMessage"] = "Selected employees updated successfully.";
            //    return RedirectToAction("MainPage");
            //}


            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
