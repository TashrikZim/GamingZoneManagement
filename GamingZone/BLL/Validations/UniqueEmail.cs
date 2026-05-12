using DAL.EF;
using System.ComponentModel.DataAnnotations;

namespace BLL.Validations
{
    public class UniqueEmail : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var db = (GamingZoneDbContext)validationContext.GetService(typeof(GamingZoneDbContext));

            if (db != null)
            {
                var u = (from user in db.Users
                         where user.Email.Equals(value.ToString())
                         select user).FirstOrDefault();

                if (u == null)
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult("Email Exists");
            }

            return new ValidationResult("Enter Email");
        }
    }
}