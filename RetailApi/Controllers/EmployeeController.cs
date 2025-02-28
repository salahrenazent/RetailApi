﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetailApi.DAL.Interfaces;
using RetailApi.Models;

namespace RetailApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        [Route("list")]
        public List<Employee> List()
        {
            List<Employee> employees = new List<Employee>();

            try
            {
                
                employees = _employeeService.GetAllEmployees();
            }
            catch (Exception ex)
            {
            }
            return employees.ToList();
        }

        [HttpPost]
        [Route("select/{id:int}")]
        public Employee Select(int id)
        {
            Employee objEmployees = new Employee();
            try
            {
                
                objEmployees = _employeeService.GetItems(id);
            }
            catch (Exception ex)
            {

            }

            return objEmployees;
        }

        [HttpPost]
        [Route("save")]
        public EmployeeResponse SaveData(Employee storeData)
        {
            EmployeeResponse res = new EmployeeResponse();

            try
            {
                
                Int32 ID = _employeeService.SaveData(storeData);

                res.flag = "1";
                res.message = "Success";
                res.data = _employeeService.GetItems(ID);
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
        public EmployeeResponse Delete(int id)
        {
            EmployeeResponse res = new EmployeeResponse();

            try
            {
                

                _employeeService.DeleteEmployees(id);
                res.flag = "1";
                res.message = "Success";
                res.data = _employeeService.GetItems(id);
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
