using Journal.Database.Context;
using Journal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Journal.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly DatabaseService _dbService;
        private readonly TestDataService _testDataService;
        private readonly JournalContext _dbContext;

        public IndexModel(ILogger<IndexModel> logger, DatabaseService dbService, TestDataService testDataService, JournalContext dbContext)
        {
            _logger = logger;
            _dbService = dbService;
            _testDataService = testDataService;
            _dbContext = dbContext;
        }

        public void OnGet()
        {

        }

        public int GetApplicationCount()
        {
            //_testDataService.CreateApplications();
            //_dbContext.SaveChanges();
            return _dbService.GetApplicationCount();
        }
    }
}
