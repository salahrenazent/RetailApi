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
        [HttpPost]
        [Route("update")]
        public GRNResponse Update(PurchHeader Data)
        {
            GRNResponse res = new GRNResponse();

            try
            {

                _PurchaseInvoiceService.Update(Data);
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

        //[HttpPost]
        //[Route("select/{id:int}")]
        //public GRN select(int id)
        //{
        //    GRN objScheme = new GRN();
        //    try
        //    {

        //        objScheme = _PurchaseInvoiceService.GetGRN(id);
        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //    return objScheme;
        //}

        //[HttpPost]
        //[Route("delete/{id:int}")]
        //public GRNResponse Delete(int id)
        //{
        //    GRNResponse res = new GRNResponse();

        //    try
        //    {


        //        _PurchaseInvoiceService.Delete(id);
        //        res.Flag = 1;
        //        res.Message = "Success";

        //    }
        //    catch (Exception ex)
        //    {
        //        res.Flag = 0;
        //        res.Message = ex.Message;
        //    }
        //    return res;
        //}

        //[HttpPost]
        //[Route("verify")]
        //public GRNResponse Verify(GRN Data)
        //{
        //    GRNResponse res = new GRNResponse();

        //    try
        //    {

        //        _PurchaseInvoiceService.Verify(Data);
        //        res.Flag = 1;
        //        res.Message = "Success";
        //    }
        //    catch (Exception ex)
        //    {
        //        res.Flag = 0;
        //        res.Message = ex.Message;
        //    }

        //    return res;
        //}

        //[HttpPost]
        //[Route("list")]
        //public GRNResponse List()
        //{
        //    GRNResponse res = new GRNResponse();
        //    List<GRN> grn = new List<GRN>();

        //    try
        //    {
        //        string apiKey = "";
        //        Int32 intUserID = 1;


        //        grn = _PurchaseInvoiceService.GetGRNList(intUserID);

        //        res.Flag = 1;
        //        res.Message = "Success";
        //        res.grnheader = grn;
        //    }
        //    catch (Exception ex)
        //    {
        //        res.Flag = 0;
        //        res.Message = ex.Message;
        //    }

        //    return res;
        //}

        //[HttpPost]
        //[Route("approve")]
        //public GRNResponse Approve(GRN Data)
        //{
        //    GRNResponse res = new GRNResponse();

        //    try
        //    {

        //        _PurchaseInvoiceService.Approve(Data);
        //        res.Flag = 1;
        //        res.Message = "Success";
        //    }
        //    catch (Exception ex)
        //    {
        //        res.Flag = 0;
        //        res.Message = ex.Message;
        //    }

        //    return res;
        //}
    }
}
