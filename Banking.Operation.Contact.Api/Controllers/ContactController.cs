using Banking.Operation.Contact.Domain.Abstractions.Exceptions;
using Banking.Operation.Contact.Domain.Abstractions.Messages;
using Banking.Operation.Contact.Domain.Contact.Dtos;
using Banking.Operation.Contact.Domain.Contact.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banking.Operation.Contact.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("/v{version:apiVersion}/banking-operation/{clientid}/contacts")]
    [ApiController]
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;
        private readonly IContactService _ContactService;

        public ContactController(ILogger<ContactController> logger, IContactService ContactService)
        {
            _logger = logger;
            _ContactService = ContactService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ResponseContactDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(List<BussinessMessage>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<ResponseContactDto>>> GetAll(Guid clientid)
        {
            _logger.LogInformation("Receive GetAll...");

            try
            {
                var contact = await _ContactService.GetAll(clientid);

                if (!contact.Any())
                {
                    return NoContent();
                }

                return Ok(contact);
            }
            catch (BussinessException bex)
            {
                return BadRequest(new BussinessMessage(bex.Type, bex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetAll exception: {ex}");
                throw;
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResponseContactDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(List<BussinessMessage>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetOne(Guid clientid, Guid id)
        {
            _logger.LogInformation("Receive GetOne...");

            try
            {
                var Contact = await _ContactService.GetOne(clientid, id);

                if (Contact is null)
                {
                    return NoContent();
                }

                return Ok(Contact);
            }
            catch (BussinessException bex)
            {
                return BadRequest(new BussinessMessage(bex.Type, bex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetOne exception: {ex}");
                throw;
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseContactDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<BussinessMessage>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Save(Guid clientid, RequestContactDto client)
        {
            _logger.LogInformation("Receive Save...");

            try
            {
                var ContactSaved = await _ContactService.Save(clientid, client);

                return Ok(ContactSaved);
            }
            catch (BussinessException bex)
            {
                return BadRequest(new BussinessMessage(bex.Type, bex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Save exception: {ex}");
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ResponseContactDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<BussinessMessage>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Update(Guid clientid, Guid id, RequestContactDto Contact)
        {
            _logger.LogInformation("Receive Update...");

            try
            {
                var ContactSaved = await _ContactService.Update(clientid, id, Contact);

                return Ok(ContactSaved);
            }
            catch (BussinessException bex)
            {
                return BadRequest(new BussinessMessage(bex.Type, bex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Update exception: {ex}");
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<BussinessMessage>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(Guid clientid, Guid id)
        {
            _logger.LogInformation("Receive Delete...");

            try
            {
                await _ContactService.Delete(clientid, id);

                return Ok();
            }
            catch (BussinessException bex)
            {
                return BadRequest(new BussinessMessage(bex.Type, bex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Delete exception: {ex}");
                return BadRequest();
            }
        }
    }
}
