using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using assignment3_db.db;
using assignment3_db.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace assignment3_db.Controllers
{

    public class LoginController : Controller
    {
        private readonly EmbeddedStockContext _context;

        public LoginController(EmbeddedStockContext context)
        {
            _context = context;
        }
        [HttpPost]
        public ActionResult<string> Index([FromBody]User user)
        {
            try
            {
                var u = _context.User.FirstOrDefault(user1 => user1.Name==user.Name);
                if (u == null)
                {
                    return BadRequest("No user with matching params");
                }


                var jwt = new JsonWebTokenHandler();
                var symmectic = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("My vevvy secret key"));
                var signed = new SigningCredentials(symmectic, SecurityAlgorithms.HmacSha512Signature);
                var token  = jwt.CreateToken(JsonConvert.SerializeObject(u), signed);

                var b = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("My vevvy secret key"))
                };

                var a = jwt.ValidateToken(token,b);

                return Ok(token);
            }
            catch (Exception e)
            {
                return BadRequest("An error happended " + e.Message);
            }

        }
    }
}