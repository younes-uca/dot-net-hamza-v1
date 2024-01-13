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
    public class AchatItemsController : ControllerBase
    {
        private readonly AchatItemAdminService _achatItemService;

        public AchatItemsController(AchatItemAdminService achatItemService)
        {
            _achatItemService = achatItemService;
        }

        // GET: api/AchatItem
        [HttpGet]
        public ActionResult<IEnumerable<AchatItemDto>> GetAchatItems()
        {
            return Ok(_achatItemService.GetAchatItems());
        }

        // GET: api/AchatItem/5
        [HttpGet("{id}")]
        public ActionResult<AchatItemDto> GetAchatItem(int id)
        {
            return Ok(_achatItemService.GetAchatItem(id));
        }

        // PUT: api/AchatItem/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutAchatItem(int id, AchatItemDto achatItem)
        {
            _achatItemService.PutAchatItem(id, achatItem);
            return Ok();
        }

        // POST: api/AchatItem
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostAchatItem(AchatItemDto achatItem)
        {
            _achatItemService.PostAchatItem(achatItem);
            return Ok();
        }

        // DELETE: api/AchatItem/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAchatItem(int id)
        {
            _achatItemService.DeleteAchatItem(id);
            return Ok();
        }
    }
}
