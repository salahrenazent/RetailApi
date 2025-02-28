using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetailApi.DAL.Interfaces;
using RetailApi.Models;

namespace RetailApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;
        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }
        [HttpPost]
        [Route("reportcoloumn")]
        public StockResponse List(StockInput input)
        {
            StockResponse res = new StockResponse();

            try
            {
                
                var result = _stockService.GetStockWithStore(input);

                res.Flag = 1;
                res.Message = "Success";
                res.Data = result.Data;
                res.Columns = result.Columns;
            }
            catch (Exception ex)
            {
                res.Flag = 0;
                res.Message = ex.Message;
            }

            return res;
        }
    }
}
