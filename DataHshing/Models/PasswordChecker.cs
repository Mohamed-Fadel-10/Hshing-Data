using Microsoft.AspNetCore.Mvc;

namespace DataHshing.Models
{
    public enum Strength
    {
        VeryStrong,
        Strong,
        Good,
        Week,
        VeryWeek
    }
    public class PasswordChecker
    {
        [Remote(action: "PasswordChecker", controller: "PasswordChecker")]
        public string CheckPassordStrength { get; set; }
        public string Message { get; set; }
        public Strength Strength { get; set; }


    }
}
