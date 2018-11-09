using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using assignment3_db.db;
using assignment3_db.Models;
using assignment3_db.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace assignment3_db.Controllers
{

    public class LoginController : Controller
    {
        private readonly EmbeddedStockContext _context;
        private readonly AuthenticationService _authentication;

        public LoginController(EmbeddedStockContext context, AuthenticationService authentication)
        {
            _context = context;
            _authentication = authentication;
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


                return Ok(_authentication.SignToken(u));
            }
            catch (Exception e)
            {
                return BadRequest("An error happended " + e.Message);
            }

        }
    }
}