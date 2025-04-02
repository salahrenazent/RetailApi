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
    public class DesignationController : ControllerBase
    {
        private readonly IDesignationService _DesignationService;
        public DesignationController(IDesignationService DesignationService)
        {
            _DesignationService = DesignationService;
        }
        [HttpPost]
        [Route("list")]
        public DesignationResponse List()
        {
            DesignationResponse res = new DesignationResponse();
            try
            {
                res.datas = _DesignationService.GetAllDesignations();
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
        public DesignationResponse Select(int id)
        {
            DesignationResponse responce = new DesignationResponse();
            try
            {
                responce.data = _DesignationService.GetDesignationById(id);
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
        public DesignationResponse SaveData(Designation designationData)
        {
            DesignationResponse res = new DesignationResponse();
            try
            {
                Int32 ID = _DesignationService.SaveDesignation(designationData);
                res.flag = "1";
                res.message = "Success";
                res.data = _DesignationService.GetDesignationById(ID);
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
        public DesignationResponse EditData(Designation designationData)
        {
            DesignationResponse res = new DesignationResponse();
            try
            {
                Int32 ID = _DesignationService.SaveDesignation(designationData);
                res.flag = "1";
                res.message = "Success";
                res.data = _DesignationService.GetDesignationById(ID);
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
        public DesignationResponse Delete(int id)
        {
            DesignationResponse res = new DesignationResponse();
            try
            {
                _DesignationService.DeleteDesignation(id);
                res.flag = "1";
                res.message = "Success";
                res.data = _DesignationService.GetDesignationById(id);
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
