using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WebAPI.Services;
using WebAPI.Services.DTOs;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserTitleController : Controller
    {
        private readonly IUserTitleService _userTitleService;
        private readonly ILogger _logger;

        public UserTitleController(IUserTitleService userTitleService, ILogger<UserController> logger)
        {
            _userTitleService = userTitleService ?? throw new System.ArgumentNullException(nameof(userTitleService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public ActionResult<List<UserTitleDTO>> Get()
        {
            try
            {
                var userTitle = _userTitleService.GetUserTitle();

                return Ok(userTitle);
            }
            catch (Exception ex) when (ex is ArgumentOutOfRangeException)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                throw ex;
            }
        }
    }
}
