using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetailApi.DAL.Interfaces;
using RetailApi.Models;

namespace RetailApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UomController : ControllerBase
    {
        private readonly IUomService _uomService;
        public UomController(IUomService uomService)
        {
            _uomService = uomService;
        }
        [HttpPost]
        [Route("list")]
        public List<Uom> List()
        {
            List<Uom> uoms = new List<Uom>();
            Uom res = new Uom();
            try
            {
                
                uoms = _uomService.GetAllUom();

                res.flag = "1";
                res.message = "Success";
            }
            catch (Exception ex)
            {
            }
            return uoms.ToList();
        }

        [HttpPost]
        [Route("select/{id:int}")]
        public Uom Select(int id)
        {
            Uom objUom = new Uom();
            Uom res = new Uom();
            try
            {
                
                objUom = _uomService.GetItems(id);

                res.flag = "1";
                res.message = "Success";

            }
            catch (Exception ex)
            {

            }

            return objUom;
        }

        [HttpPost]
        [Route("insert")]
        public Uom insert(Uom uom)
        {
            Uom res = new Uom();
            try
            {
                
                _uomService.Insert(uom);

                res.flag = "1";
                res.message = "Success";
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
        public Uom Update(Uom uom)
        {
            Uom res = new Uom();
            try
            {
                
                _uomService.Update(uom);

                res.flag = "1";
                res.message = "Success";
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
        public Uom Delete(int id)
        {
            Uom res = new Uom();

            try
            {
                

                _uomService.DeleteUom(id);
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
