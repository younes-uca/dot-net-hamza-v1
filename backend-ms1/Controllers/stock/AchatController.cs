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
    public class AchatsController : ControllerBase
    {
        private readonly AchatAdminService _achatService;

        public AchatsController(AchatAdminService achatService)
        {
            _achatService = achatService;
        }

        // GET: api/Achat
        [HttpGet]
        public ActionResult<IEnumerable<AchatDto>> GetAchats()
        {
            return Ok(_achatService.GetAchats());
        }

        // GET: api/Achat/5
        [HttpGet("{id}")]
        public ActionResult<AchatDto> GetAchat(int id)
        {
            return Ok(_achatService.GetAchat(id));
        }

        // PUT: api/Achat/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutAchat(int id, AchatDto achat)
        {
            _achatService.PutAchat(id, achat);
            return Ok();
        }

        // POST: api/Achat
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostAchat(AchatDto achat)
        {
            _achatService.PostAchat(achat);
            return Ok();
        }

        // DELETE: api/Achat/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAchat(int id)
        {
            _achatService.DeleteAchat(id);
            return Ok();
        }
    }
}
