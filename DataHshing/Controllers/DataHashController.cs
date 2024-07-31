using DataHshing.Models;
using DataHshing.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace DataHshing.Controllers
{
    public class DataHashController : Controller
    {
        private readonly IHashingDataRepository _hashingDataRepository;
        public DataHashController(IHashingDataRepository _hashingDataRepository)
        {
            this._hashingDataRepository= _hashingDataRepository;
        }
        public IActionResult Index(PasswordHash model)
        {

            return View("Index", model);
        }
        public async Task<IActionResult> DataHashing(PasswordHash model)
        {
            if (model is not null) 
            {
               var Response=await _hashingDataRepository.HashDataWithSaltAsync(model);
                return View("DataHashing", Response);
            }
            return RedirectToAction("Index");
        }

    }
}
