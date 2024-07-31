using DataHshing.Models;
using DataHshing.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace DataHshing.Controllers
{
    public class PasswordCheckerController : Controller
    {
        private readonly IPasswordCheckerRepository _passwordChecker;
        public PasswordCheckerController(IPasswordCheckerRepository _passwordChecker)
        {
            this._passwordChecker = _passwordChecker;   
        }

        public IActionResult Index(PasswordChecker model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Strength = CheckPasswordStrength(model.CheckPassordStrength);
            }
            return View("PasswordChecker", model);
        }
       // [HttpPost]

        public IActionResult CheckStrength(PasswordChecker model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Strength = CheckPasswordStrength(model.CheckPassordStrength);
            }
            return View("PasswordChecker", model);
        }
        public IActionResult Result()
        {
            return View();
        }

        private string CheckPasswordStrength(string password)
        {
            int score = 0;

            if (password.Length >= 8)
                score++;
            if (Regex.IsMatch(password, @"[a-z]"))
                score++;
            if (Regex.IsMatch(password, @"[A-Z]"))
                score++;
            if (Regex.IsMatch(password, @"[0-9]"))
                score++;
            if (Regex.IsMatch(password, @"[\W_]"))
                score++;

            switch (score)
            {
                case 5:
                    return "Very Strong";
                case 4:
                    return "Strong";
                case 3:
                    return "Medium";
                case 2:
                    return "Weak";
                default:
                    return "Very Weak";
            }
        }
    }
}
