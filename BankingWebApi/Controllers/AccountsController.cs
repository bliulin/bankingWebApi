using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Banking.Business.Contracts;
using Banking.Data.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BankingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ILogger<AccountsController> _logger;
        private readonly IAccountService _accountsDataProvider;

        public AccountsController(ILogger<AccountsController> logger, IAccountService accountsDataProvider)
        {
            _logger = logger;
            _accountsDataProvider = accountsDataProvider;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Read currently logged in user id from the HTTP header.
            string clientIdHeaderValue = Request.Headers["X-ClientId"].FirstOrDefault();
            Guid clientId = !string.IsNullOrEmpty(clientIdHeaderValue) ? new Guid(clientIdHeaderValue) : Guid.Empty;

            var items = await _accountsDataProvider.GetClientAccounts(clientId);

            return Ok(items);
        }
    }
}
