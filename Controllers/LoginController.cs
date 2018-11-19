using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assignment3_db.db;
using assignment3_db.Models;
using assignment3_db.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace assignment3_db.Controllers
{
    public class LoginController : Controller
    {
        private EmbeddedStockContext _embeddedStock;
        private IValidationService _validationService;

        public LoginController(EmbeddedStockContext embeddedStock, IValidationService validationService)
        {
            _embeddedStock = embeddedStock;
            _validationService = validationService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login([Bind("Username, Password")] Authentication login)
        {
            var u = await _embeddedStock.User.FirstOrDefaultAsync(i => i.Name == login.Username);
            return BCrypt.Net.BCrypt.Verify(login.Password, u.Password)
                ? RedirectToAction("Index", "Home", new {token=_validationService.SignToken(u)})
                : RedirectToAction(nameof(Index));
        }
    }
}