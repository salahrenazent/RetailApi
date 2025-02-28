using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetailApi.DAL.Interfaces;
using RetailApi.Models;

namespace RetailApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/tranferin")]
    public class TransferInController : ControllerBase
    {
        private readonly ITransferInService _transferInService;
        public TransferInController(ITransferInService transferInService)
        {
            _transferInService = transferInService;
        }
        [HttpPost]
        [Route("transferlist")]
        public TransferListResponse ItemDetails(StoreInput input)
        {
            TransferListResponse res = new TransferListResponse();

            try
            {
                
                var result = _transferInService.GetItems(input);

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
        public TransferInResponse Insert(TransferIn Data)
        {
            TransferInResponse res = new TransferInResponse();

            try
            {
                
                _transferInService.Insert(Data);
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
        public TransferInResponse Update(TransferIn Data)
        {
            TransferInResponse res = new TransferInResponse();

            try
            {
                
                _transferInService.Update(Data);
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
        public TransferInResponse Verify(TransferIn Data)
        {
            TransferInResponse res = new TransferInResponse();

            try
            {
                
                _transferInService.Verify(Data);
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
        [Route("delete/{id:int}")]
        public TransferInResponse Delete(int id)
        {
            TransferInResponse res = new TransferInResponse();

            try
            {
                

                _transferInService.Delete(id);
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
