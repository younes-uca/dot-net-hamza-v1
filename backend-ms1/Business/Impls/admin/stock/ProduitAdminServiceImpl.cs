using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Stocky.Business.Contracts;
using Stocky.Data;
using Stocky.Models.DTO;
using Stocky.Models;
using Stocky.Models.Dtos;

namespace Stocky.Business.Impls
{
    public class  ProduitAdminServiceImpl : ProduitAdminService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public  ProduitAdminServiceImpl(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<ProduitDto> GetProduits()
        {
            if (_context.produits == null)
            {
                throw new ApplicationException("not found");
            }
            return _mapper.Map<IEnumerable<ProduitDto>>(_context.produits.ToList());
        }

        public ProduitDto GetProduit(int id)
        {
            var produit = _context.produits.FirstOrDefault(c => c.Id == id);

            if (produit == null)
            {
                throw new ApplicationException("not found");
            }

            return _mapper.Map<ProduitDto>(produit);
        }

        public void PutProduit(int id, ProduitDto produit)
        {
            if (!ProduitExists(id))
            {
                throw new ApplicationException("not found");
            }
            Produit updatedProduit = _mapper.Map<Produit>(produit);
            _context.Entry(updatedProduit).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void PostProduit(ProduitDto produit)
        {
            if (ProduitExists(produit.Id))
            {
                throw new ApplicationException("Already exist");
            }
            Produit savedProduit = _mapper.Map<Produit>(produit);
            _context.produits.Add(savedProduit);
            _context.SaveChanges();
        }

        public void DeleteProduit(int id)
        {
            if (!ProduitExists(id))
            {
                throw new ApplicationException("not found");
            }

            _context.produits.Remove(removedProduit);
            _context.SaveChanges();
        }

        private bool ProduitExists(int id)
        {
            return (_context.produits?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
