using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetailApi.DAL.Interfaces;
using RetailApi.Models;

namespace RetailApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ReportTemplateController : ControllerBase
    {
        private readonly IReportTemplateService _reportTemplateService;
        public ReportTemplateController(IReportTemplateService reportTemplateService)
        {
            _reportTemplateService = reportTemplateService;
        }
        [HttpPost]
        [Route("list")]
        public ReportTemplateResponse List()
        {
            ReportTemplateResponse res = new ReportTemplateResponse();
            List<ReportTemplate> reportTemplates = new List<ReportTemplate>();
            try
            {
                string apiKey = "";
                Int32 intUserID = 1;

                /*
                foreach (var header in Request.Headers)
                {
                    if (header.Key == "x-api-key")
                        apiKey = header.Value.ToList()[0];
                }

                        
                User_DAL userDAL = new User_DAL();
                Int32 intUserID = userDAL.GetUserIDWithToken(apiKey);
                if (intUserID < 1)
                {
                    res.flag = "0";
                    res.message = "Invalid authorization key";
                    return res;
                }

                */

                
                reportTemplates = _reportTemplateService.GetReportTemplates();

                res.flag = "1";
                res.message = "Success";
                res.data = reportTemplates;
            }
            catch (Exception ex)
            {
                res.flag = "0";
                res.message = ex.Message;
            }

            return res;
        }

        [HttpPost]
        [Route("default")]
        public ReportTemplateResponse Insert(ReportInput input)
        {
            ReportTemplateResponse res = new ReportTemplateResponse();
            try
            {
                
                _reportTemplateService.CheckDefault(input);

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

        [HttpPost]
        [Route("reportlist")]
        public ReportTemplateResponse ReportList(ReportInput input)
        {
            ReportTemplateResponse res = new ReportTemplateResponse();
            List<ReportOutput> report = new List<ReportOutput>();
            try
            {
                string apiKey = "";
                Int32 intUserID = 1;

                /*
                foreach (var header in Request.Headers)
                {
                    if (header.Key == "x-api-key")
                        apiKey = header.Value.ToList()[0];
                }

                        
                User_DAL userDAL = new User_DAL();
                Int32 intUserID = userDAL.GetUserIDWithToken(apiKey);
                if (intUserID < 1)
                {
                    res.flag = "0";
                    res.message = "Invalid authorization key";
                    return res;
                }

                */

                
                report = _reportTemplateService.GetReportOutput(input);

                res.flag = "1";
                res.message = "Success";
                res.datalist = report;
            }
            catch (Exception ex)
            {
                res.flag = "0";
                res.message = ex.Message;
            }

            return res;
        }

        [HttpPost]
        [Route("templatelist")]
        public ReportTemplateResponse TemplateList(ReportInput input)
        {
            ReportTemplateResponse res = new ReportTemplateResponse();
            List<ReportTemplate> templateList = new List<ReportTemplate>();
            try
            {
                string apiKey = "";
                Int32 intUserID = 1;

                /*
                foreach (var header in Request.Headers)
                {
                    if (header.Key == "x-api-key")
                        apiKey = header.Value.ToList()[0];
                }

                        
                User_DAL userDAL = new User_DAL();
                Int32 intUserID = userDAL.GetUserIDWithToken(apiKey);
                if (intUserID < 1)
                {
                    res.flag = "0";
                    res.message = "Invalid authorization key";
                    return res;
                }

                */

                
                templateList = _reportTemplateService.GetTemplateList(input);

                res.flag = "1";
                res.message = "Success";
                res.data = templateList;
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
