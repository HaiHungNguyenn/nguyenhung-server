using Microsoft.AspNetCore.Mvc;
using NguyenHung.Api.Constants;
using NguyenHung.Common.Exceptions;
using NguyenHung.Service.Models.Common;

namespace NguyenHung.Api.Controllers.BaseController;
[ApiController]
[Route("/api/[controller]")]
public class BaseApiController : ControllerBase
{
    private IActionResult BuildSuccessResult(ServiceActionResult result)
    {
        var successResult = new ApiResponse(true)
        {
            Data = result.Data,
            StatusCode = result.StatusCode != default ? result.StatusCode : StatusCodes.Status200OK
        };

        var detail = result.Detail ?? ApiMessageConstant.Success;
        successResult.AddSuccessMessage(detail);
        return base.Ok(successResult);
    }

    private IActionResult BuildErrorResult(Exception e)
    {
        var errorResult = new ApiResponse(false);
        errorResult.AddErrorMessage(e.Message);

        var statusCode = StatusCodes.Status500InternalServerError;
        if (e.GetType().IsAssignableTo(typeof(INotFoundException)))
            statusCode = StatusCodes.Status404NotFound;
        else if (e.GetType().IsAssignableTo(typeof(IBusinessException)))
            statusCode = StatusCodes.Status409Conflict;
        else if (e.GetType().IsAssignableTo(typeof(IForbiddenException)))
            statusCode = StatusCodes.Status403Forbidden;
        else if (e.GetType().IsAssignableFrom(typeof(IBadRequestException)))
            statusCode = StatusCodes.Status400BadRequest;
        errorResult.StatusCode = statusCode;
        return base.StatusCode(errorResult.StatusCode,new {error = errorResult.Messages});
    }
    protected async Task<IActionResult> ExecuteServiceLogic(Func<Task<ServiceActionResult>> serviceActionFunc)
    {
        return await ExecuteServiceLogic(serviceActionFunc, null);
    }
    
    protected async Task<IActionResult> ExecuteServiceLogic(Func<Task<ServiceActionResult>> serviceActionFunc,
        Func<Task<ServiceActionResult>>? errorHandler)
    {
        try
        {
            var result = await serviceActionFunc();
            return result.IsSuccess ? BuildSuccessResult(result) : Problem(result.Detail);
        }
        catch (Exception e)
        {
            return BuildErrorResult(e);
        }
     
    }
}