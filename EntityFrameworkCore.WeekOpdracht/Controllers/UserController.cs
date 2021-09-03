using EntityFrameworkCore.WeekOpdracht.Business.Entities;
using EntityFrameworkCore.WeekOpdracht.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NLog.Web;
using System;

namespace EntityFrameworkCore.WeekOpdracht.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly NLog.Logger logger;

        public UserController(IUserService userService)
        {
            this.logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            this.userService = userService;
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            try
            {
                logger.Info("Create User Called");
                var saved = userService.Add(user);

                return Ok(saved);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return BadRequest(new
                {
                    Message = ex.Message,
                });
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                logger.Info("Get User By ID Called");
                return Ok(userService.Get(id));
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return BadRequest(new
                {
                    Message = ex.Message,
                });
            }
        }

    }
}
