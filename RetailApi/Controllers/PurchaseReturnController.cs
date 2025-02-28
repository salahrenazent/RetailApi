using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetailApi.DAL.Interfaces;
using RetailApi.Models;

namespace RetailApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseReturnController : ControllerBase
    {
        private readonly IPurchaseReturnService _purchaseReturnService;
        public PurchaseReturnController(IPurchaseReturnService purchaseReturnService)
        {
            _purchaseReturnService = purchaseReturnService;
        }
        [HttpPost]
        [Route("GrnList")]
        public GRN_Response GRNList(Input input)
        {
            GRN_Response res = new GRN_Response();

            try
            {
                
                var result = _purchaseReturnService.GetGrn(input);

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
        [Route("GrnData")]
        public GRN_Response GRNData(GrnInput input)
        {
            GRN_Response res = new GRN_Response();

            try
            {
                
                var result = _purchaseReturnService.GetGrnDetails(input);

                res.Flag = 1;
                res.Message = "Success";
                res.Grndata = result;

            }
            catch (Exception ex)
            {
                res.Flag = 0;
                res.Message = ex.Message;
            }

            return res;
        }

        [HttpPost]
        [Route("insert")]
        public PurchaseReturnResponse Insert(PurchaseReturn Data)
        {
            PurchaseReturnResponse res = new PurchaseReturnResponse();

            try
            {
                
                _purchaseReturnService.Insert(Data);
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
        public PurchaseReturnResponse Update(PurchaseReturn Data)
        {
            PurchaseReturnResponse res = new PurchaseReturnResponse();

            try
            {
                
                _purchaseReturnService.Update(Data);
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
        [Route("select/{id:int}")]
        public PurchaseReturn select(int id)
        {
            PurchaseReturn objScheme = new PurchaseReturn();
            try
            {
                
                objScheme = _purchaseReturnService.GetPurchaseReturn(id);
            }
            catch (Exception ex)
            {

            }

            return objScheme;
        }

        [HttpPost]
        [Route("list")]
        public PurchaseReturnResponse List()
        {
            PurchaseReturnResponse res = new PurchaseReturnResponse();
            List<PurchaseReturn> purchaseReturns = new List<PurchaseReturn>();

            try
            {
                string apiKey = "";
                Int32 intUserID = 1;


                
                purchaseReturns = _purchaseReturnService.List();

                res.Flag = 1;
                res.Message = "Success";
                res.data = purchaseReturns;
            }
            catch (Exception ex)
            {
                res.Flag = 0;
                res.Message = ex.Message;
            }

            return res;
        }


        [HttpPost]
        [Route("delete/{id:int}")]
        public PurchaseReturnResponse Delete(int id)
        {
            PurchaseReturnResponse res = new PurchaseReturnResponse();

            try
            {
                

                _purchaseReturnService.Delete(id);
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
        [Route("verify")]
        public PurchaseReturnResponse Verify(PurchaseReturn Data)
        {
            PurchaseReturnResponse res = new PurchaseReturnResponse();

            try
            {
                
                _purchaseReturnService.Verify(Data);
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
        [Route("approve")]
        public PurchaseReturnResponse Approve(PurchaseReturn Data)
        {
            PurchaseReturnResponse res = new PurchaseReturnResponse();

            try
            {
                
                _purchaseReturnService.Approve(Data);
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
