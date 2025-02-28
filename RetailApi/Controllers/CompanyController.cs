using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetailApi.DAL.Interfaces;
using RetailApi.Models;

namespace RetailApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost]
        [Route("list")]
        public List<Company> List()
        {
            List<Company> companies = new List<Company>();

            try
            {
                
                companies = _companyService.GetAllCompany();
            }
            catch (Exception ex)
            {
            }
            return companies.ToList();
        }

        [HttpPost]
        [Route("select/{id:int}")]
        public Company Select(int id)
        {
            Company objCompany = new Company();
            try
            {
                
                objCompany = _companyService.GetItems(id);
            }
            catch (Exception ex)
            {

            }

            return objCompany;
        }

        [HttpPost]
        [Route("save")]
        public CompanyResponse SaveData(Company companyData)
        {
            CompanyResponse res = new CompanyResponse();

            try
            {
                
                Int32 ID = _companyService.SaveData(companyData);

                res.flag = "1";
                res.message = "Success";
                res.data = _companyService.GetItems(ID);
            }
            catch (Exception ex)
            {
                res.flag = "1";
                res.message = ex.Message;
            }

            return res;
        }


        [HttpGet]
        [Route("delete/{id:int}")]
        public CompanyResponse Delete(int id)
        {
            CompanyResponse res = new CompanyResponse();

            try
            {
                

                _companyService.DeleteCompany(id);
                res.flag = "1";
                res.message = "Success";
                res.data = _companyService.GetItems(id);
            }
            catch (Exception ex)
            {
                res.flag = "0";
                res.message = ex.Message;
            }
            return res;
        }

        [HttpPost]
        [Route("Doclist")]
        public List<DocSettings> DocSettings()
        {
            List<DocSettings> companies = new List<DocSettings>();

            try
            {
                
                companies = _companyService.GetAllDocSettings();
            }
            catch (Exception ex)
            {
            }
            return companies.ToList();
        }
    }
}
