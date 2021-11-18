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
    public class UserTypeController : Controller
    {
        private readonly IUserTypeService _userTypeService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UserTypeController(IUserTypeService userTypeService, IMapper mapper, ILogger<UserController> logger)
        {
            _userTypeService = userTypeService ?? throw new System.ArgumentNullException(nameof(userTypeService));
            _mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<ActionResult<List<UserTypeDTO>>> Get()
        {
            try
            {
                var userTypes = await _userTypeService.GetUserTypesAsync();

                var userTypesAfterMapping = _mapper.Map<List<UserTypeDTO>>(userTypes);

                return Ok(userTypesAfterMapping);
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
