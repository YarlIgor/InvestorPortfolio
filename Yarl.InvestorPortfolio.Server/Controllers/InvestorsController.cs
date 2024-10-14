using Microsoft.AspNetCore.Mvc;
using Yarl.InvestorPortfolio.Services.Interfaces;

namespace ReactApp2.Server.Controllers
{
    [ApiController]
    [Route("investors")]
    public class InvestorsController : ControllerBase
    {
        private readonly ILogger<InvestorsController> _logger;
        private readonly IInvestorService _investorService;
        private readonly ICommitmentService _commitmentService;

        public InvestorsController(IInvestorService investorService, ICommitmentService commitmentService, ILogger<InvestorsController> logger)
        {
            _investorService = investorService;
            _commitmentService = commitmentService;
            _logger = logger;
        }

        [HttpGet()]
        public async Task<IActionResult> GetInvestors()
        {
            var investors = await _investorService.GetAll();
            return Ok(investors);
        }

        [HttpGet("{investorId}/commitments")]
        public async Task<IActionResult> GetCommitments(long investorId)
        {
            var commitments = await _commitmentService.GetCommitments(investorId);
            return Ok(commitments);
        }
    }
}
