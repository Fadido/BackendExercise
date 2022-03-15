using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Exercise_Tikal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private IMessageService _messageService;
        private readonly ILogger<MessagesController> _logger;

        public MessagesController(IMessageService messageService, ILogger<MessagesController> logger)
        {
            _logger = logger;
            _messageService = messageService;
        }

        [HttpPost]
        [Route("SendMessage")]
        public IActionResult SendMessage(MessageDetails messageDetails)
        {
            try
            {
                ValidateArguments(messageDetails);
                _messageService.SaveMessage(messageDetails);
                return Ok();
            }
            catch(ArgumentException ex)
            {
                _logger.LogInformation(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetMessages")]
        public IActionResult GetMessages(int? recipientId)
        {
            try
            {
                if (recipientId == null)
                    throw new ArgumentException("recipientId cannot be null");
                var x =_messageService.GetMessagesByRecipientId(recipientId.Value);
                return Ok(x);
            }
            catch (ArgumentException ex)
            {
                _logger.LogInformation(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return BadRequest();
            }
            
        }

        private void ValidateArguments(object obj)
        {
            if (obj == null)
                throw new ArgumentException($"{obj.GetType().Name} cannot null");
            var props = obj.GetType().GetProperties();
            foreach (var prop in props)
            {
                if (prop.GetValue(obj) == null)
                    throw new ArgumentException($"{prop.Name} cannot be null");
            }
        }
    }
}
