using Domain.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Select(m => new
                {
                    Key = m.Key.ToCharArray()[0].ToString().ToLower() + m.Key.Substring(1, m.Key.Length - 1),

                    Errors = m.Value.Errors.Select(x => x.ErrorMessage)
                }).ToDictionary(x => x.Key, y => y.Errors.ToList());

                context.Result = new BadRequestObjectResult(new ResponseObject<string, object>
                {
                    Message = "Form data not validated.",
                    InternalMessage = "Many validation errors.",
                    Result = "",
                    Model = null,
                    Errors = errors,
                    Success = false
                });
            }

            base.OnActionExecuting(context);
        }
    }
}
