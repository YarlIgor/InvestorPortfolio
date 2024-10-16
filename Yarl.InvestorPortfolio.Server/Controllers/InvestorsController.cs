using Microsoft.AspNetCore.Mvc;
using Yarl.InvestorPortfolio.Core.Enums;
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
        public async Task<IActionResult> GetCommitments(long investorId, AssetClasses assetClass = AssetClasses.All, int pageSize = 20, int pageNumber = 1)
        {
            var commitments = await _commitmentService.GetCommitments(investorId, assetClass, pageSize, pageNumber);
            var commitmentsCount = await _commitmentService.GetCommitmentsCount(investorId, assetClass);
            return Ok(new { commitments, commitmentsCount });
        }

        [HttpGet("{investorId}/assets")]
        public async Task<IActionResult> GetAssets(long investorId)
        {
            var assets = await _investorService.GetAssetsSummmaries(investorId);
            return Ok(new { assets, investorId });
        }
    }
}
