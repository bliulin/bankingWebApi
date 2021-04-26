using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Banking.Business.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        [Route("report/{iban}")]
        public async Task<IActionResult> Report(string iban)
        {
            // Read the X-Date field from the HTTP header, if present. This will be used as the DateTimeOffset.
            // Specification: RFC 7231 7.1.1.3: Date
            // example: Date: Wed, 21 Oct 2015 07:28:00 GMT

            DateTimeOffset dateTimeOffset = DateTime.UtcNow;
            if (Request.Headers.ContainsKey("X-Date"))
            {
                string value = Request.Headers["X-Date"].FirstOrDefault();
                DateTimeOffset.TryParse(value, out dateTimeOffset);
            }

            var report = await _transactionService.GetTransactionsForLastMonth(dateTimeOffset, iban);
            return Ok(report.OrderBy(r => r.CategoryName));
        }
    }
}
