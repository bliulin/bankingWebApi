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
        public async Task<IActionResult> Report(string iban)
        {
            var report = await _transactionService.GetTransactionsForLastMonth(DateTime.Now, iban);
            return Ok(report);
        }
    }
}
