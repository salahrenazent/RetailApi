using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetailApi.DAL.Interfaces;
using RetailApi.DAL.Services;
using RetailApi.Helper;
using RetailApi.Models;
using System.Data.SqlClient;

namespace RetailApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SalaryHeadController : ControllerBase
    {
        private readonly ISalaryHeadService _SalaryHeadService;
        public SalaryHeadController(ISalaryHeadService SalaryHeadService)
        {
            _SalaryHeadService = SalaryHeadService;
        }
        [HttpPost]
        [Route("list")]
        public SalaryHeadResponse List()
        {
            SalaryHeadResponse res = new SalaryHeadResponse();

            try
            {
                res.datas = _SalaryHeadService.GetAllSalaryHead();
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
        public SalaryHead Select(int id)
        {
            SalaryHead salaryHead = new SalaryHead();

            try
            {
                salaryHead = _SalaryHeadService.GetItem(id);
            }
            catch (Exception ex)
            {
                // Handle exception
            }

            return salaryHead;
        }

        [HttpPost]
        [Route("save")]
        public SalaryHeadResponse SaveData(SalaryHead salaryHeadData)
        {
            SalaryHeadResponse res = new SalaryHeadResponse();

            try
            {
                Int32 ID = _SalaryHeadService.SaveData(salaryHeadData);

                res.flag = "1";
                res.message = "Success";
                res.data = _SalaryHeadService.GetItem(ID);
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
        public SalaryHeadResponse EditData(SalaryHead salaryHeadData)
        {
            SalaryHeadResponse res = new SalaryHeadResponse();

            try
            {
                Int32 ID = _SalaryHeadService.EditData(salaryHeadData);

                res.flag = "1";
                res.message = "Success";
                res.data = _SalaryHeadService.GetItem(ID);
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
        public SalaryHeadResponse Delete(int id)
        {
            SalaryHeadResponse res = new SalaryHeadResponse();

            try
            {
                _SalaryHeadService.DeleteSalaryHead(id);
                res.flag = "1";
                res.message = "Success";
                res.data = _SalaryHeadService.GetItem(id);
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
