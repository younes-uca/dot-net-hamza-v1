using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stocky.Business.Contracts;
using Stocky.Data;
using Stocky.Models;
using Stocky.Models.DTO;

namespace Stocky.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ClientAdminService _clientService;

        public ClientsController(ClientAdminService clientService)
        {
            _clientService = clientService;
        }

        // GET: api/Client
        [HttpGet]
        public ActionResult<IEnumerable<ClientDto>> GetClients()
        {
            return Ok(_clientService.GetClients());
        }

        // GET: api/Client/5
        [HttpGet("{id}")]
        public ActionResult<ClientDto> GetClient(int id)
        {
            return Ok(_clientService.GetClient(id));
        }

        // PUT: api/Client/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutClient(int id, ClientDto client)
        {
            _clientService.PutClient(id, client);
            return Ok();
        }

        // POST: api/Client
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostClient(ClientDto client)
        {
            _clientService.PostClient(client);
            return Ok();
        }

        // DELETE: api/Client/5
        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            _clientService.DeleteClient(id);
            return Ok();
        }
    }
}
