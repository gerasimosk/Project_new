using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Services;
using WebAPI.Services.DTOs;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserTitleController : Controller
    {
        private readonly IUserTitleService _userTitleService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UserTitleController(IUserTitleService userTitleService, IMapper mapper, ILogger<UserController> logger)
        {
            _userTitleService = userTitleService ?? throw new System.ArgumentNullException(nameof(userTitleService));
            _mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>Gets the user titles.</summary>
        /// <returns>Lists of user titles.</returns>
        [HttpGet]
        public async Task<ActionResult<List<UserTitleDTO>>> Get()
        {
            try
            {
                var userTitles = await _userTitleService.GetUserTitlesAsync();

                var userTitlesAfterMapping = _mapper.Map<List<UserTitleDTO>>(userTitles);

                return Ok(userTitlesAfterMapping);
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
