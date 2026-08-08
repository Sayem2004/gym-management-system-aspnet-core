using DAL.EF;
using System.ComponentModel.DataAnnotations;

namespace BLL.Validations
{
    public class UniqueUname : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var db = (GymManagementDbContext)validationContext.GetService(typeof(GymManagementDbContext));

            if (value != null)
            {
                var u = (from user in db.Users
                         where user.Username.Equals(value.ToString())
                         select user).SingleOrDefault();

                if (u == null)
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult("Username Exists");
            }

            return new ValidationResult("Data Required");
        }
    }
}