using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetailApi.DAL.Interfaces;
using RetailApi.Helper;
using RetailApi.Models;
using System.Data.SqlClient;

namespace RetailApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _DepartmentService;
        public DepartmentController(IDepartmentService DepartmentService)
        {
            _DepartmentService = DepartmentService;
        }
        [HttpPost]
        [Route("list")]
        public DepartmentResponse List()
        {
            DepartmentResponse res = new DepartmentResponse();

            try
            {
                res.datas = _DepartmentService.GetAllDepartments();
            }
            catch (Exception ex)
            {
                res.flag = "0";
                res.message = ex.Message;
            }
            return res;
        }

        [HttpPost]
        [Route("select/{id:int}")]
        public DepartmentResponse Select(int id)
        {
            DepartmentResponse responce = new DepartmentResponse();

            try
            {
                responce.data = _DepartmentService.GetDepartmentById(id);
            }
            catch (Exception ex)
            {
                responce.flag = "0";
                responce.message = ex.Message;
            }

            return responce;
        }

        [HttpPost]
        [Route("save")]
        public DepartmentResponse SaveData(Department departmentData)
        {
            DepartmentResponse res = new DepartmentResponse();

            try
            {
                Int32 ID = _DepartmentService.SaveDepartment(departmentData);

                res.flag = "1";
                res.message = "Success";
                res.data = _DepartmentService.GetDepartmentById(ID);
            }
            catch (Exception ex)
            {
                res.flag = "0";
                res.message = ex.Message;
            }

            return res;
        }

        [HttpPost]
        [Route("edit")]
        public DepartmentResponse EditData(Department departmentData)
        {
            DepartmentResponse res = new DepartmentResponse();

            try
            {
                Int32 ID = _DepartmentService.SaveDepartment(departmentData);

                res.flag = "1";
                res.message = "Success";
                res.data = _DepartmentService.GetDepartmentById(ID);
            }
            catch (Exception ex)
            {
                res.flag = "0";
                res.message = ex.Message;
            }

            return res;
        }

        [HttpPost]
        [Route("delete/{id:int}")]
        public DepartmentResponse Delete(int id)
        {
            DepartmentResponse res = new DepartmentResponse();

            try
            {
                _DepartmentService.DeleteDepartment(id);
                res.flag = "1";
                res.message = "Success";
                res.data = _DepartmentService.GetDepartmentById(id);
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
