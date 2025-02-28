using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetailApi.DAL.Interfaces;
using RetailApi.Models;

namespace RetailApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TransferOutController : ControllerBase
    {
        private readonly ITransferOutService _transferOutService;
        public TransferOutController(ITransferOutService transferOutService)
        {
            _transferOutService = transferOutService;
        }
        [HttpPost]
        [Route("ItemList")]
        public ItemDetailsResponse ItemDetails(InputStore input)
        {
            ItemDetailsResponse res = new ItemDetailsResponse();

            try
            {
                
                var result = _transferOutService.GetItems(input);

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
        [Route("insert")]
        public TransferOutResponse Insert(TransferOut Data)
        {
            TransferOutResponse res = new TransferOutResponse();

            try
            {
                
                _transferOutService.Insert(Data);
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
        public TransferOutResponse Update(TransferOut Data)
        {
            TransferOutResponse res = new TransferOutResponse();

            try
            {
                
                _transferOutService.Update(Data);
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
        public TransferOutResponse Verify(TransferOut Data)
        {
            TransferOutResponse res = new TransferOutResponse();

            try
            {
                
                _transferOutService.Verify(Data);
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
        public TransferOutResponse Apporve(TransferOut Data)
        {
            TransferOutResponse res = new TransferOutResponse();

            try
            {
                
                _transferOutService.Approve(Data);
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
        [Route("delete/{id:int}")]
        public TransferOutResponse Delete(int id)
        {
            TransferOutResponse res = new TransferOutResponse();

            try
            {
                

                _transferOutService.Delete(id);
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
        [Route("list")]
        public TransferOutResponse List()
        {
            TransferOutResponse res = new TransferOutResponse();
            List<TransferOut> transferOuts = new List<TransferOut>();

            try
            {
                string apiKey = "";
                Int32 intUserID = 1;

                
                transferOuts = _transferOutService.List(intUserID);

                res.Flag = 1;
                res.Message = "Success";
                res.data = transferOuts;
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
        public TransferOut select(int id)
        {
            TransferOut objScheme = new TransferOut();
            try
            {
                
                objScheme = _transferOutService.GetTransferOut(id);
            }
            catch (Exception ex)
            {

            }

            return objScheme;
        }
    }
}
