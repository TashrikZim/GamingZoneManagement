using DAL.EF;
using System.ComponentModel.DataAnnotations;

namespace BLL.Validations
{
    public class UniqueUsername : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var db = (GamingZoneDbContext)validationContext.GetService(typeof(GamingZoneDbContext));

            if (value != null)
            {
                var u = (from user in db.Users
                         where user.UserName.Equals(value.ToString())
                         select user).SingleOrDefault();

                if (u == null)
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult("UserName Exists");
            }

            return new ValidationResult("Username required");
        }
    }
}