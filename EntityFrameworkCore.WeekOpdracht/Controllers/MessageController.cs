using EntityFrameworkCore.WeekOpdracht.Business.Entities;
using EntityFrameworkCore.WeekOpdracht.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NLog.Web;
using System;

namespace EntityFrameworkCore.WeekOpdracht.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService messageService;
        private readonly NLog.Logger logger;

        public MessageController(IMessageService messageService)
        {
            this.logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            this.messageService = messageService;
        }

        [HttpPost]
        public IActionResult Create(Message message)
        {
            try
            {
                logger.Info("Create Message Called");
                return Ok(messageService.Add(message));
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return BadRequest(new
                {
                    Message = ex.Message
                });
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                logger.Info("Get Message By ID Called");
                return Ok(messageService.GetById(id));
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return BadRequest(new
                {
                    Message = ex.Message
                });
            }
        }

        [HttpGet]
        [Route("user/{userId}")]
        public IActionResult GetByUserId(int userId)
        {
            try
            {
                logger.Info("Get Messages By User ID called");
                return Ok(messageService.Get(userId));
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return BadRequest(new
                {
                    Message = ex.Message
                });
            }
        }
    }
}
