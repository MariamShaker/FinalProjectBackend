using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SELP.API.Base;
using SELP.Core.Features.Authentication.Command.Models;
using SELP.Core.Features.AuthenticationUser.Commands.Models;
using SELP.Data.AppMetaData;
using Swashbuckle.AspNetCore.Annotations;
using SELP.Core.Features.Authentication.Command.Models;
using SELP.Core.Features.Authentication.Query.Models;
using Microsoft.AspNetCore.Authorization;

namespace SELP.API.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : AppControllerBase
    {
        [AllowAnonymous]
        //Create User
        [HttpPost(Router.Authentication.SignIn)]
        public async Task<IActionResult> Create([FromForm] SignInCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpGet(Router.Authentication.ConfirmEmail)]
        //"توثيق الحساب

        public async Task<IActionResult> ConfirmEmail([FromQuery] ComfirmEmail query)
        {
            var response = await Mediator.Send(query);
            return NewResult(response);
        }
        //reset pass
        //ارسال الكود للمستخدم

        [HttpGet(Router.Authentication.SendResetPassword)]

        public async Task<IActionResult> SendResetPassword([FromQuery] ResetPasswordCommand query)
        {
            var response = await Mediator.Send(query);
            return NewResult(response);
        }

        //confirm reset pass
        //تجربة ادخال الكود الذي تم ارسالة للمستخدم
        [HttpGet(Router.Authentication.ConfirmResetPass)]

        public async Task<IActionResult> ConfirmResetPass([FromQuery] ResetPasswordQuery query)
        {
            var response = await Mediator.Send(query);
            return NewResult(response);
        }
        //تغيير الرقم السري بعد التاكد من الكود
        [HttpPost(Router.Authentication.ChangePassword)]
        public async Task<IActionResult> ChangePassword([FromForm] ConfirmResetPassCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }
}
