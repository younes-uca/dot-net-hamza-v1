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
    public class ProduitsController : ControllerBase
    {
        private readonly ProduitAdminService _produitService;

        public ProduitsController(ProduitAdminService produitService)
        {
            _produitService = produitService;
        }

        // GET: api/Produit
        [HttpGet]
        public ActionResult<IEnumerable<ProduitDto>> GetProduits()
        {
            return Ok(_produitService.GetProduits());
        }

        // GET: api/Produit/5
        [HttpGet("{id}")]
        public ActionResult<ProduitDto> GetProduit(int id)
        {
            return Ok(_produitService.GetProduit(id));
        }

        // PUT: api/Produit/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutProduit(int id, ProduitDto produit)
        {
            _produitService.PutProduit(id, produit);
            return Ok();
        }

        // POST: api/Produit
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostProduit(ProduitDto produit)
        {
            _produitService.PostProduit(produit);
            return Ok();
        }

        // DELETE: api/Produit/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduit(int id)
        {
            _produitService.DeleteProduit(id);
            return Ok();
        }
    }
}
