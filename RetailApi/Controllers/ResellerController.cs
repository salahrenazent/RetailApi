using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetailApi.DAL.Interfaces;
using RetailApi.Models;

namespace RetailApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ResellerController : ControllerBase
    {
        private readonly IResellerService _resellerService;
        public ResellerController(IResellerService resellerService)
        {
            _resellerService = resellerService;
        }
        [HttpGet]
        public List<Reseller> Resellers()
        {
            List<Reseller> Resellers = new List<Reseller>();

            try
            {
                
                Resellers = _resellerService.GetAllReseller();
            }
            catch (Exception ex)
            {
            }
            return Resellers.ToList();
        }

        [HttpGet]
        [Route("select/{id:int}")]
        public Reseller Reseller(int id)
        {

            Reseller objReseller = new Reseller();
            try
            {
                
                objReseller = _resellerService.GetItems(id);
            }
            catch (Exception ex)
            {

            }

            return objReseller;
        }

        [HttpPost]
        [Route("insert")]
        public ResellerResponse Insert(Reseller resellerData)
        {
            ResellerResponse res = new ResellerResponse();
            try
            {
                
                Int32 ResellerID = _resellerService.Insert(resellerData);

                res.flag = "1";
                res.message = "Success";
                res.data = _resellerService.GetItems(ResellerID);
            }
            catch (Exception ex)
            {
                res.flag = "1";
                res.message = ex.Message;

            }

            return res;
        }

        [HttpPost]
        [Route("update")]
        public Response Update(Reseller resellerData)
        {
            Response res = new Response();
            try
            {
                
                _resellerService.Update(resellerData);
                res.flag = "1";
                res.message = "Success";
            }
            catch (Exception ex)
            {
                res.flag = "0";
                res.message = ex.Message;
            }

            return res;
        }

        [HttpGet]
        [Route("delete/{id:int}")]
        public Response Delete(int id)
        {
            Response res = new Response();

            try
            {
                

                _resellerService.DeleteReseller(id);
                res.flag = "1";
                res.message = "Success";
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
