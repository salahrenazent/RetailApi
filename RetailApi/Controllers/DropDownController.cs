using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetailApi.DAL.Interfaces;
using RetailApi.Models;

namespace RetailApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DropDownController : ControllerBase
    {
        private readonly IDropDownService _dropDownService;
        public DropDownController(IDropDownService dropDownService)
        {
            _dropDownService = dropDownService;
        }
        [HttpPost]
        public List<DropDown> ListData(DropDownInput vInput)
        {
            List<DropDown> vData = new List<DropDown>();
            try
            {
                
                vData = _dropDownService.GetDropDownData(vInput.NAME);
            }
            catch (Exception ex)
            {

            }
            return vData.ToList();
        }
    }
}
