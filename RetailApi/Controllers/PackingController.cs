using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetailApi.DAL.Interfaces;
using RetailApi.Models;

namespace RetailApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PackingController : ControllerBase
    {
        private readonly IPackingService _packingService;
        public PackingController(IPackingService packingService)
        {
            _packingService = packingService;
        }
        [HttpPost]
        [Route("list")]
        public List<Packing> List()
        {
            List<Packing> packings = new List<Packing>();
            Packing res = new Packing();
            try
            {
                
                packings = _packingService.GetAllPacking();

                res.flag = "1";
                res.message = "Success";
            }
            catch (Exception ex)
            {
            }
            return packings.ToList();
        }

        [HttpPost]
        [Route("select/{id:int}")]
        public Packing Select(int id)
        {
            Packing objPacking = new Packing();
            Packing res = new Packing();
            try
            {
                
                objPacking = _packingService.GetItems(id);

                res.flag = "1";
                res.message = "Success";
            }
            catch (Exception ex)
            {

            }
            return objPacking;
        }
        [HttpPost]
        [Route("insert")]
        public Packing insert(Packing Packings)
        {
            Packing res = new Packing();
            try
            {
                
                _packingService.Insert(Packings);

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
        public Packing Update(Packing Packings)
        {
            Packing res = new Packing();
            try
            {
                
                _packingService.Update(Packings);

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
        public Packing Delete(int id)
        {
            Packing res = new Packing();

            try
            {
                

                _packingService.DeletePacking(id);
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
