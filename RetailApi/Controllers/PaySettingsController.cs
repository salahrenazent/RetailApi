using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetailApi.DAL.Interfaces;
using RetailApi.Helper;
using RetailApi.Models;
using System.Data.SqlClient;

namespace RetailApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PaySettingsController : ControllerBase
    {
        private readonly IPaySettingsService _PaySettingsService;
        public PaySettingsController(IPaySettingsService PaySettingsService)
        {
            _PaySettingsService = PaySettingsService;
        }
        [HttpPost("get")]
        public ActionResult<PaySettingsResponce> Get()
        {
            try
            {
                PaySettingsResponce responce = new PaySettingsResponce();
                responce.data = _PaySettingsService.GetPaySettings();
                responce.flag = "1";
                responce.message = "success";

                return Ok(responce);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("save")]
        public IActionResult Save([FromBody] PaySettings settings)
        {
            try
            {
                PaySettingsResponce responce = new PaySettingsResponce();
                _PaySettingsService.SavePaySettings(settings);
                responce.data = _PaySettingsService.GetPaySettings();
                responce.flag = "1";
                responce.message = "Saved successfully";
                return Ok(responce);
            }
            catch (Exception ex)
            {
                return BadRequest(new { flag = 0, message = ex.Message });
            }
        }
    }
}
