using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RebarMock.Identity.Models;

namespace RebarMock.Identity.IdentityControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;

        public AccountsController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser([FromBody]UserModel userModel)
        {
            var user = new IdentityUser { UserName = userModel.UserName, Email = userModel.Email };
            var result = await _userManager.CreateAsync(user , userModel.Password);
            if (result.Succeeded)
            {
                return (Ok(new {Sucess=true, Message = "Regitration successfull"}));
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPost("signIn")]
        public async Task<ActionResult> Login([FromBody]UserModel userModel)
        {
            var result = await _signInManager.PasswordSignInAsync(userModel.UserName, userModel.Password,true, lockoutOnFailure:false);
            if(result.Succeeded)
            {
                return Ok("You are signed in");
            }
            else
            {
                return BadRequest(result);
            }
        }

    }
}
