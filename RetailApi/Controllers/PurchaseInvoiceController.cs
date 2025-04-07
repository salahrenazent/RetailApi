using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetailApi.DAL.Interfaces;
using RetailApi.DAL.Services;
using RetailApi.Helper;
using RetailApi.Models;
using System.Data.SqlClient;

namespace RetailApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseInvoiceController : ControllerBase
    {
        private readonly IPurchaseInvoiceService _PurchaseInvoiceService;
        public PurchaseInvoiceController(IPurchaseInvoiceService PurchaseInvoiceService)
        {
            _PurchaseInvoiceService = PurchaseInvoiceService;
        }
        [HttpPost]
        [Route("GetPendingPoList")]
        public PIDropdownResponce PendingPoList(PIDropdownInput input)
        {
            PIDropdownResponce res = new PIDropdownResponce();
            try
            {

                var result = _PurchaseInvoiceService.GetPendingPoList(input);

                res.Flag = 1;
                res.Message = "Success";
                res.data = result;

            }
            catch (Exception ex)
            {
                res.Flag = 0;
                res.Message = ex.Message;
            }

            return res;
        }

        [HttpPost]
        [Route("GetGrnDetails")]
        public GRNDetailResponce POList(GRNDetailInput input)
        {
            GRNDetailResponce res = new GRNDetailResponce();
            try
            {



                var result = _PurchaseInvoiceService.GetSelectedPoDetailS(input);


                res.Flag = 1;
                res.Message = "Success";
                res.GRNDetails = result.GRNDetails;

                return res; // Return the response
            }
            catch (Exception ex)
            {

                res.Flag = 0;
                res.Message = "Error: " + ex.Message; // Include error message


                return res; // Return the error response
            }
        }
        [HttpPost]
        [Route("insert")]
        public GRNResponse Insert(PurchHeader Data)
        {
            GRNResponse res = new GRNResponse();

            try
            {

                _PurchaseInvoiceService.Insert(Data);
                res.Flag = 1;
                res.Message = "Success";
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
