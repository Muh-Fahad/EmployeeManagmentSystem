using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.ApplicationLayer.DTOs;
using RepositoryPattern.ApplicationLayer.Interfaces;

namespace RepositoryPattern.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogHistoryController : ControllerBase
    {
        private readonly ILogHistoryService _logHistoryService;

        public LogHistoryController(ILogHistoryService logHistoryService)
        {
            _logHistoryService = logHistoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var logs = await _logHistoryService.GetAllAsync();
            return Ok(logs);
        }

        
    }
}
    

