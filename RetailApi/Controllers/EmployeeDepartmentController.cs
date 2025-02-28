using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetailApi.DAL.Interfaces;
using RetailApi.Models;

namespace RetailApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeDepartmentController : ControllerBase
    {
        private readonly IEmployeeDepartmentService _employeeDepartmentService;
        public EmployeeDepartmentController(IEmployeeDepartmentService employeeDepartmentService)
        {
            _employeeDepartmentService = employeeDepartmentService;
        }
        [HttpPost]
        [Route("list")]
        public List<EmployeeDepartment> List()
        {
            List<EmployeeDepartment> companies = new List<EmployeeDepartment>();

            try
            {
                
                companies = _employeeDepartmentService.GetAllDepartment();
            }
            catch (Exception ex)
            {
            }
            return companies.ToList();
        }

        [HttpPost]
        [Route("select/{id:int}")]
        public EmployeeDepartment Select(int id)
        {
            EmployeeDepartment objDepartment = new EmployeeDepartment();
            try
            {
                
                objDepartment = _employeeDepartmentService.GetItems(id);
            }
            catch (Exception ex)
            {

            }

            return objDepartment;
        }

        [HttpPost]
        [Route("save")]
        public EmployeeDepartmentResponse SaveData(EmployeeDepartment departmentData)
        {
            EmployeeDepartmentResponse res = new EmployeeDepartmentResponse();

            try
            {
                
                Int32 ID = _employeeDepartmentService.SaveData(departmentData);

                res.flag = "1";
                res.message = "Success";
                res.data = _employeeDepartmentService.GetItems(ID);

            }
            catch (Exception ex)
            {
                res.flag = "1";
                res.message = ex.Message;
            }

            return res;
        }

        [HttpPost]
        [Route("delete/{id:int}")]
        public EmployeeDepartmentResponse Delete(int id)
        {
            EmployeeDepartmentResponse res = new EmployeeDepartmentResponse();

            try
            {
                

                _employeeDepartmentService.DeleteDepartment(id);
                res.flag = "1";
                res.message = "Success";
                res.data = _employeeDepartmentService.GetItems(id);
            }
            catch (Exception ex)
            {
                res.flag = "0";
                res.message = ex.Message;
            }
            return res;
        }
    }
}
